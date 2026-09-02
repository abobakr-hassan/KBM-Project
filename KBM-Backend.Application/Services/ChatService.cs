using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using KBM_Backend.Application.DTOs.Chat;
using KBM_Backend.Application.Interfaces;

namespace KBM_Backend.Application.Services;

public class ChatService : IChatService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ChatService> _logger;

    public ChatService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<ChatService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<ChatResponseDto> AskAsync(ChatRequestDto request)
    {
        var apiKey = _configuration["Gemini:ApiKey"];

        var payload = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = request.Message }
                    }
                }
            }
        };

        using var httpRequest = new HttpRequestMessage(
            HttpMethod.Post,
            "https://generativelanguage.googleapis.com/v1beta/models/gemini-3.6-flash:generateContent");

        httpRequest.Headers.Add("x-goog-api-key", apiKey);
        httpRequest.Content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.SendAsync(httpRequest);
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Gemini API error: {Body}", body);
            return new ChatResponseDto { Reply = "Sorry, I couldn't get a response right now." };
        }

        using var doc = JsonDocument.Parse(body);
        var reply = doc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString() ?? string.Empty;

        return new ChatResponseDto { Reply = reply };
    }
}