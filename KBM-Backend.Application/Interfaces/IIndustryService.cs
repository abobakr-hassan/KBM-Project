using KBM_Backend.Application.DTOs.Industry;

namespace KBM_Backend.Application.Interfaces;

public interface IIndustryService
{
    Task<IEnumerable<IndustryDto>> GetAllAsync();

    Task<IndustryDto?> GetByIdAsync(Guid id);

    Task<IndustryDto> CreateAsync(CreateIndustryDto dto);

    Task<bool> UpdateAsync(Guid id, UpdateIndustryDto dto);

    Task<bool> DeleteAsync(Guid id);
}