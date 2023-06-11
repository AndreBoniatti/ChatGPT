using Newtonsoft.Json;

namespace PPI.Models.Dtos;

public class ChatDto
{
    [JsonProperty("model")]
    public string Model { get; set; } = String.Empty;

    [JsonProperty("temperature")]
    public double Temperature { get; set; }

    [JsonProperty("messages")]
    public List<MessageDto>? Messages { get; set; }
}