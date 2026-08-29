using Asp.Versioning;
using KBM_Backend.Application.DTOs.Industry;
using KBM_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KBM_Backend.Api.Controllers;

[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class IndustriesController : ControllerBase
{
    private readonly IIndustryService _industryService;

    public IndustriesController(IIndustryService industryService)
    {
        _industryService = industryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IndustryDto>>> GetAll()
    {
        var industries = await _industryService.GetAllAsync();

        return Ok(industries);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<IndustryDto>> GetById(Guid id)
    {
        var industry = await _industryService.GetByIdAsync(id);

        if (industry is null)
        {
            return NotFound();
        }

        return Ok(industry);
    }

    [HttpPost]
    public async Task<ActionResult<IndustryDto>> Create(
        CreateIndustryDto dto)
    {
        var industry = await _industryService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = industry.Id },
            industry);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateIndustryDto dto)
    {
        var updated = await _industryService.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _industryService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}