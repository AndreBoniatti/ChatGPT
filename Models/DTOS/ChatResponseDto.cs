using Newtonsoft.Json;

namespace PPI.Models.Dtos;

public class ChatResponseDto
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("object")]
    public string Object { get; set; } = string.Empty;

    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("choices")]
    public List<ChoiceDto>? Choices { get; set; }

    [JsonProperty("usage")]
    public UsageDto? Usage { get; set; }
}

public class ChoiceDto
{
    [JsonProperty("index")]
    public int Index { get; set; }

    [JsonProperty("message")]
    public MessageDto? Message { get; set; }

    [JsonProperty("finish_reason")]
    public string FinishReason { get; set; } = string.Empty;
}

public class UsageDto
{
    [JsonProperty("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonProperty("completion_tokens")]
    public int CompletionTokens { get; set; }

    [JsonProperty("total_tokens")]
    public int TotalTokens { get; set; }
}