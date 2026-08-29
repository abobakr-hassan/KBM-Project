using KBM_Backend.Application.DTOs.Department;

namespace KBM_Backend.Application.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDto>> GetAllAsync();

    Task<DepartmentDto?> GetByIdAsync(Guid id);

    Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto);

    Task<bool> UpdateAsync(Guid id, UpdateDepartmentDto dto);

    Task<bool> DeleteAsync(Guid id);
}