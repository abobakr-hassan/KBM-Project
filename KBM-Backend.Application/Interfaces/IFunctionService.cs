using KBM_Backend.Application.DTOs.Function;

namespace KBM_Backend.Application.Interfaces;

public interface IFunctionService
{
    Task<IEnumerable<FunctionDto>> GetAllAsync();

    Task<FunctionDto?> GetByIdAsync(Guid id);

    Task<FunctionDto> CreateAsync(CreateFunctionDto dto);

    Task<bool> UpdateAsync(Guid id, UpdateFunctionDto dto);

    Task<bool> DeleteAsync(Guid id);
}