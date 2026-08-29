using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KBM_Backend.Application.DTOs.Department;
using KBM_Backend.Application.Interfaces;
using KBM_Backend.Domain.Entities;

namespace KBM_Backend.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IKbmDbContext _context;
    private readonly ILogger<DepartmentService> _logger;

    public DepartmentService(
        IKbmDbContext context,
        ILogger<DepartmentService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        _logger.LogInformation("Getting all departments");

        var departments = await _context.Departments
            .AsNoTracking()
            .ToListAsync();

        _logger.LogInformation(
            "Retrieved {Count} departments",
            departments.Count);

        return departments.Adapt<IEnumerable<DepartmentDto>>();
    }

    public async Task<DepartmentDto?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation(
            "Getting department with ID {DepartmentId}",
            id);

        var department = await _context.Departments
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);

        if (department is null)
        {
            _logger.LogWarning(
                "Department with ID {DepartmentId} was not found",
                id);

            return null;
        }

        return department.Adapt<DepartmentDto>();
    }

    public async Task<DepartmentDto> CreateAsync(
        CreateDepartmentDto dto)
    {
        _logger.LogInformation(
            "Creating department with name {DepartmentName}",
            dto.Name);

        var department = new Department
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };

        _context.Departments.Add(department);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Department with ID {DepartmentId} was created successfully",
            department.Id);

        return department.Adapt<DepartmentDto>();
    }

    public async Task<bool> UpdateAsync(
        Guid id,
        UpdateDepartmentDto dto)
    {
        _logger.LogInformation(
            "Updating department with ID {DepartmentId}",
            id);

        var department = await _context.Departments
            .FirstOrDefaultAsync(d => d.Id == id);

        if (department is null)
        {
            _logger.LogWarning(
                "Department with ID {DepartmentId} was not found for update",
                id);

            return false;
        }

        department.Name = dto.Name;
        department.ModifiedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Department with ID {DepartmentId} was updated successfully",
            id);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        _logger.LogInformation(
            "Deleting department with ID {DepartmentId}",
            id);

        var department = await _context.Departments
            .FirstOrDefaultAsync(d => d.Id == id);

        if (department is null)
        {
            _logger.LogWarning(
                "Department with ID {DepartmentId} was not found for deletion",
                id);

            return false;
        }

        _context.Departments.Remove(department);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Department with ID {DepartmentId} was deleted successfully",
            id);

        return true;
    }
}