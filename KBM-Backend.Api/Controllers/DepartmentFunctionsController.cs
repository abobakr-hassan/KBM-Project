using Asp.Versioning;
using KBM_Backend.Application.DTOs.Function;
using KBM_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KBM_Backend.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/departments")]
public class DepartmentFunctionsController : ControllerBase
{
    private readonly IDepartmentFunctionService _service;

    public DepartmentFunctionsController(
        IDepartmentFunctionService service)
    {
        _service = service;
    }

    [HttpPost("{departmentId:guid}/functions/{functionId:guid}")]
    public async Task<IActionResult> AddFunction(
        Guid departmentId,
        Guid functionId)
    {
        var added = await _service.AddFunctionToDepartmentAsync(
            departmentId,
            functionId);

        if (!added)
        {
            return Conflict(
                "This function is already assigned to the department.");
        }

        return NoContent();
    }

    [HttpDelete("{departmentId:guid}/functions/{functionId:guid}")]
    public async Task<IActionResult> RemoveFunction(
        Guid departmentId,
        Guid functionId)
    {
        var removed = await _service.RemoveFunctionFromDepartmentAsync(
            departmentId,
            functionId);

        if (!removed)
        {
            return NotFound(
                "The department-function relationship was not found.");
        }

        return NoContent();
    }

    [HttpGet("{departmentId:guid}/functions")]
    public async Task<ActionResult<IEnumerable<FunctionDto>>> GetFunctions(
        Guid departmentId)
    {
        var functions =
            await _service.GetFunctionsByDepartmentAsync(departmentId);

        return Ok(functions);
    }
}