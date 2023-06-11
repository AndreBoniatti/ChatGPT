using System.Text;
using Newtonsoft.Json;
using PPI.Clients.Contracts;
using PPI.Models.DTOS;

namespace PPI.Clients;

public class OpenAIClient : IOpenAIClient
{
    private readonly HttpClient _httpClient;

    public OpenAIClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ChatResponseDto?> CreateChatCompletionAsync(ChatDto chat)
    {
        var response = await _httpClient.PostAsync("/v1/chat/completions", GetRequestContent(chat));
        var stringResponse = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            return null;

        var jsonResponse = JsonConvert.DeserializeObject<ChatResponseDto>(stringResponse);
        return jsonResponse;
    }

    private StringContent GetRequestContent<T>(T data)
    {
        return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
    }
}