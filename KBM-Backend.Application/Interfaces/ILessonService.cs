using KBM_Backend.Application.DTOs.Lesson;

namespace KBM_Backend.Application.Interfaces;

public interface ILessonService
{
    Task<IEnumerable<LessonDto>> GetAllAsync();

    Task<LessonDto?> GetByIdAsync(Guid id);

    Task<LessonDto> CreateAsync(CreateLessonDto dto);

    Task<bool> UpdateAsync(Guid id, UpdateLessonDto dto);

    Task<bool> DeleteAsync(Guid id);
}