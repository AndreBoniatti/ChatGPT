using Newtonsoft.Json;

namespace PPI.Models.DTOS;

public class ChatDto
{
    [JsonProperty("model")]
    public string Model { get; set; } = String.Empty;

    [JsonProperty("messages")]
    public List<MessageDto>? Messages { get; set; }
}