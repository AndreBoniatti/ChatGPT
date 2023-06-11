using Newtonsoft.Json;

namespace PPI.Models.Dtos;

public class MessageDto
{
    [JsonProperty("role")]
    public string Role { get; set; } = String.Empty;

    [JsonProperty("content")]
    public string Content { get; set; } = String.Empty;
}