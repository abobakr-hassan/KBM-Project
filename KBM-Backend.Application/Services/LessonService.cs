using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KBM_Backend.Application.DTOs.Lesson;
using KBM_Backend.Application.Interfaces;
using KBM_Backend.Domain.Entities;

namespace KBM_Backend.Application.Services;

public class LessonService : ILessonService
{
    private readonly IKbmDbContext _context;
    private readonly ILogger<LessonService> _logger;

    public LessonService(
        IKbmDbContext context,
        ILogger<LessonService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<LessonDto>> GetAllAsync()
    {
        _logger.LogInformation("Getting all lessons");

        var lessons = await _context.Lessons
            .AsNoTracking()
            .ToListAsync();

        _logger.LogInformation(
            "Retrieved {Count} lessons",
            lessons.Count);

        return lessons.Adapt<IEnumerable<LessonDto>>();
    }

    public async Task<LessonDto?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation(
            "Getting lesson with ID {LessonId}",
            id);

        var lesson = await _context.Lessons
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id);

        if (lesson is null)
        {
            _logger.LogWarning(
                "Lesson with ID {LessonId} was not found",
                id);

            return null;
        }

        return lesson.Adapt<LessonDto>();
    }

    public async Task<LessonDto> CreateAsync(
        CreateLessonDto dto)
    {
        _logger.LogInformation(
            "Creating lesson with title {LessonTitle}",
            dto.Title);

        // Validate Department
        var departmentExists = await _context.Departments
            .AnyAsync(d => d.Id == dto.DepartmentId);

        if (!departmentExists)
        {
            _logger.LogWarning(
                "Department with ID {DepartmentId} was not found",
                dto.DepartmentId);

            throw new KeyNotFoundException(
                $"Department with ID {dto.DepartmentId} was not found.");
        }

        // Validate Function
        var functionExists = await _context.Functions
            .AnyAsync(f => f.Id == dto.FunctionId);

        if (!functionExists)
        {
            _logger.LogWarning(
                "Function with ID {FunctionId} was not found",
                dto.FunctionId);

            throw new KeyNotFoundException(
                $"Function with ID {dto.FunctionId} was not found.");
        }

        // Validate Industry
        var industryExists = await _context.Industries
            .AnyAsync(i => i.Id == dto.IndustryId);

        if (!industryExists)
        {
            _logger.LogWarning(
                "Industry with ID {IndustryId} was not found",
                dto.IndustryId);

            throw new KeyNotFoundException(
                $"Industry with ID {dto.IndustryId} was not found.");
        }

        var lesson = new Lesson
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            ProjectName = dto.ProjectName,
            DepartmentId = dto.DepartmentId,
            FunctionId = dto.FunctionId,
            IndustryId = dto.IndustryId,
            ValueProposition = dto.ValueProposition,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            PersonToContact = dto.PersonToContact,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };

        _context.Lessons.Add(lesson);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Lesson with ID {LessonId} was created successfully",
            lesson.Id);

        return lesson.Adapt<LessonDto>();
    }

    public async Task<bool> UpdateAsync(
        Guid id,
        UpdateLessonDto dto)
    {
        _logger.LogInformation(
            "Updating lesson with ID {LessonId}",
            id);

        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(l => l.Id == id);

        if (lesson is null)
        {
            _logger.LogWarning(
                "Lesson with ID {LessonId} was not found for update",
                id);

            return false;
        }

        // Validate Department
        var departmentExists = await _context.Departments
            .AnyAsync(d => d.Id == dto.DepartmentId);

        if (!departmentExists)
        {
            _logger.LogWarning(
                "Department with ID {DepartmentId} was not found",
                dto.DepartmentId);

            throw new KeyNotFoundException(
                $"Department with ID {dto.DepartmentId} was not found.");
        }

        // Validate Function
        var functionExists = await _context.Functions
            .AnyAsync(f => f.Id == dto.FunctionId);

        if (!functionExists)
        {
            _logger.LogWarning(
                "Function with ID {FunctionId} was not found",
                dto.FunctionId);

            throw new KeyNotFoundException(
                $"Function with ID {dto.FunctionId} was not found.");
        }

        // Validate Industry
        var industryExists = await _context.Industries
            .AnyAsync(i => i.Id == dto.IndustryId);

        if (!industryExists)
        {
            _logger.LogWarning(
                "Industry with ID {IndustryId} was not found",
                dto.IndustryId);

            throw new KeyNotFoundException(
                $"Industry with ID {dto.IndustryId} was not found.");
        }

        lesson.Title = dto.Title;
        lesson.ProjectName = dto.ProjectName;
        lesson.DepartmentId = dto.DepartmentId;
        lesson.FunctionId = dto.FunctionId;
        lesson.IndustryId = dto.IndustryId;
        lesson.ValueProposition = dto.ValueProposition;
        lesson.Description = dto.Description;
        lesson.ImageUrl = dto.ImageUrl;
        lesson.PersonToContact = dto.PersonToContact;
        lesson.ModifiedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Lesson with ID {LessonId} was updated successfully",
            id);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        _logger.LogInformation(
            "Deleting lesson with ID {LessonId}",
            id);

        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(l => l.Id == id);

        if (lesson is null)
        {
            _logger.LogWarning(
                "Lesson with ID {LessonId} was not found for deletion",
                id);

            return false;
        }

        _context.Lessons.Remove(lesson);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Lesson with ID {LessonId} was deleted successfully",
            id);

        return true;
    }
}