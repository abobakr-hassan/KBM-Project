using Asp.Versioning;
using KBM_Backend.Application.DTOs.Function;
using KBM_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KBM_Backend.Api.Controllers;

[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class FunctionsController : ControllerBase
{
    private readonly IFunctionService _functionService;

    public FunctionsController(IFunctionService functionService)
    {
        _functionService = functionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FunctionDto>>> GetAll()
    {
        var functions = await _functionService.GetAllAsync();

        return Ok(functions);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FunctionDto>> GetById(Guid id)
    {
        var function = await _functionService.GetByIdAsync(id);

        if (function is null)
        {
            return NotFound();
        }

        return Ok(function);
    }

    [HttpPost]
    public async Task<ActionResult<FunctionDto>> Create(
        CreateFunctionDto dto)
    {
        var function = await _functionService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = function.Id },
            function);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateFunctionDto dto)
    {
        var updated = await _functionService.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _functionService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}