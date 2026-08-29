using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KBM_Backend.Application.DTOs.Function;
using KBM_Backend.Application.Interfaces;
using KBM_Backend.Domain.Entities;

namespace KBM_Backend.Application.Services;

public class FunctionService : IFunctionService
{
    private readonly IKbmDbContext _context;
    private readonly ILogger<FunctionService> _logger;

    public FunctionService(
        IKbmDbContext context,
        ILogger<FunctionService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<FunctionDto>> GetAllAsync()
    {
        _logger.LogInformation("Getting all functions");

        var functions = await _context.Functions
            .AsNoTracking()
            .ToListAsync();

        _logger.LogInformation(
            "Retrieved {Count} functions",
            functions.Count);

        return functions.Adapt<IEnumerable<FunctionDto>>();
    }

    public async Task<FunctionDto?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation(
            "Getting function with ID {FunctionId}",
            id);

        var function = await _context.Functions
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);

        if (function is null)
        {
            _logger.LogWarning(
                "Function with ID {FunctionId} was not found",
                id);

            return null;
        }

        return function.Adapt<FunctionDto>();
    }

    public async Task<FunctionDto> CreateAsync(
        CreateFunctionDto dto)
    {
        _logger.LogInformation(
            "Creating function with name {FunctionName}",
            dto.Name);

        var function = new Function
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };

        _context.Functions.Add(function);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Function with ID {FunctionId} was created successfully",
            function.Id);

        return function.Adapt<FunctionDto>();
    }

    public async Task<bool> UpdateAsync(
        Guid id,
        UpdateFunctionDto dto)
    {
        _logger.LogInformation(
            "Updating function with ID {FunctionId}",
            id);

        var function = await _context.Functions
            .FirstOrDefaultAsync(f => f.Id == id);

        if (function is null)
        {
            _logger.LogWarning(
                "Function with ID {FunctionId} was not found for update",
                id);

            return false;
        }

        function.Name = dto.Name;
        function.ModifiedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Function with ID {FunctionId} was updated successfully",
            id);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        _logger.LogInformation(
            "Deleting function with ID {FunctionId}",
            id);

        var function = await _context.Functions
            .FirstOrDefaultAsync(f => f.Id == id);

        if (function is null)
        {
            _logger.LogWarning(
                "Function with ID {FunctionId} was not found for deletion",
                id);

            return false;
        }

        _context.Functions.Remove(function);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Function with ID {FunctionId} was deleted successfully",
            id);

        return true;
    }
}