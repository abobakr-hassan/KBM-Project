using KBM_Backend.Application.DTOs.Function;

namespace KBM_Backend.Application.Interfaces;

public interface IDepartmentFunctionService
{
    Task<bool> AddFunctionToDepartmentAsync(
        Guid departmentId,
        Guid functionId);

    Task<bool> RemoveFunctionFromDepartmentAsync(
        Guid departmentId,
        Guid functionId);

    Task<IEnumerable<FunctionDto>> GetFunctionsByDepartmentAsync(
        Guid departmentId);
}