using Asp.Versioning;
using KBM_Backend.Application.DTOs.Chat;
using KBM_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KBM_Backend.Api.Controllers;

[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost]
    public async Task<ActionResult<ChatResponseDto>> Ask(ChatRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Message))
        {
            return BadRequest(new { message = "Message cannot be empty." });
        }

        var result = await _chatService.AskAsync(dto);
        return Ok(result);
    }
}