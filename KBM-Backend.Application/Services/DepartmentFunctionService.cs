using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mapster;
using KBM_Backend.Application.DTOs.Function;
using KBM_Backend.Application.Interfaces;
using KBM_Backend.Domain.Entities;

namespace KBM_Backend.Application.Services;

public class DepartmentFunctionService : IDepartmentFunctionService
{
    private readonly IKbmDbContext _context;
    private readonly ILogger<DepartmentFunctionService> _logger;

    public DepartmentFunctionService(
        IKbmDbContext context,
        ILogger<DepartmentFunctionService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> AddFunctionToDepartmentAsync(
        Guid departmentId,
        Guid functionId)
    {
        _logger.LogInformation(
            "Adding function {FunctionId} to department {DepartmentId}",
            functionId,
            departmentId);

        var departmentExists = await _context.Departments
            .AnyAsync(d => d.Id == departmentId);

        if (!departmentExists)
        {
            _logger.LogWarning(
                "Department {DepartmentId} was not found",
                departmentId);

            throw new KeyNotFoundException(
                $"Department with ID {departmentId} was not found.");
        }

        var functionExists = await _context.Functions
            .AnyAsync(f => f.Id == functionId);

        if (!functionExists)
        {
            _logger.LogWarning(
                "Function {FunctionId} was not found",
                functionId);

            throw new KeyNotFoundException(
                $"Function with ID {functionId} was not found.");
        }

        var relationshipExists =
            await _context.DepartmentFunctions.AnyAsync(
                df =>
                    df.DepartmentId == departmentId &&
                    df.FunctionId == functionId);

        if (relationshipExists)
        {
            _logger.LogWarning(
                "Function {FunctionId} is already assigned to department {DepartmentId}",
                functionId,
                departmentId);

            return false;
        }

        var departmentFunction = new DepartmentFunction
        {
            DepartmentId = departmentId,
            FunctionId = functionId
        };

        _context.DepartmentFunctions.Add(departmentFunction);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Function {FunctionId} was successfully assigned to department {DepartmentId}",
            functionId,
            departmentId);

        return true;
    }

    public async Task<bool> RemoveFunctionFromDepartmentAsync(
        Guid departmentId,
        Guid functionId)
    {
        _logger.LogInformation(
            "Removing function {FunctionId} from department {DepartmentId}",
            functionId,
            departmentId);

        var relationship = await _context.DepartmentFunctions
            .FirstOrDefaultAsync(
                df =>
                    df.DepartmentId == departmentId &&
                    df.FunctionId == functionId);

        if (relationship is null)
        {
            _logger.LogWarning(
                "Relationship between department {DepartmentId} and function {FunctionId} was not found",
                departmentId,
                functionId);

            return false;
        }

        _context.DepartmentFunctions.Remove(relationship);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Function {FunctionId} was successfully removed from department {DepartmentId}",
            functionId,
            departmentId);

        return true;
    }

    public async Task<IEnumerable<FunctionDto>> GetFunctionsByDepartmentAsync(
        Guid departmentId)
    {
        _logger.LogInformation(
            "Getting functions for department {DepartmentId}",
            departmentId);

        var departmentExists = await _context.Departments
            .AnyAsync(d => d.Id == departmentId);

        if (!departmentExists)
        {
            _logger.LogWarning(
                "Department {DepartmentId} was not found",
                departmentId);

            throw new KeyNotFoundException(
                $"Department with ID {departmentId} was not found.");
        }

        var functions = await _context.DepartmentFunctions
            .Where(df => df.DepartmentId == departmentId)
            .Select(df => df.Function)
            .AsNoTracking()
            .ToListAsync();

        _logger.LogInformation(
            "Retrieved {Count} functions for department {DepartmentId}",
            functions.Count,
            departmentId);

        return functions.Adapt<IEnumerable<FunctionDto>>();
    }
}