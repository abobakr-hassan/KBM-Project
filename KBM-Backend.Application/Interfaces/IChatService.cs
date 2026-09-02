using KBM_Backend.Application.DTOs.Chat;

namespace KBM_Backend.Application.Interfaces;

public interface IChatService
{
    Task<ChatResponseDto> AskAsync(ChatRequestDto request);
}