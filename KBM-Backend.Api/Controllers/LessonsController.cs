using Asp.Versioning;
using KBM_Backend.Application.DTOs.Lesson;
using KBM_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace KBM_Backend.Api.Controllers;

[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize]
public class LessonsController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LessonDto>>> GetAll()
    {
        var lessons = await _lessonService.GetAllAsync();

        return Ok(lessons);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LessonDto>> GetById(Guid id)
    {
        var lesson = await _lessonService.GetByIdAsync(id);

        if (lesson is null)
        {
            return NotFound();
        }

        return Ok(lesson);
    }

    [HttpPost]
    public async Task<ActionResult<LessonDto>> Create(
        CreateLessonDto dto)
    {
        try
        {
            var lesson = await _lessonService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = lesson.Id },
                lesson);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateLessonDto dto)
    {
        try
        {
            var updated = await _lessonService.UpdateAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _lessonService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}