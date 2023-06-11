using PPI.Models.DTOS;

namespace PPI.Clients.Contracts;

public interface IOpenAIClient
{
    Task<ChatResponseDto?> CreateChatCompletionAsync(ChatDto chat);
}