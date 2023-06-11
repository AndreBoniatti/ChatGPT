using PPI.Models.Dtos;

namespace PPI.Clients.Contracts;

public interface IOpenAIClient
{
    Task<ChatResponseDto?> CreateChatCompletionAsync(ChatDto chat);
}