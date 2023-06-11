using Newtonsoft.Json;

namespace PPI.Models.Dtos;

public class AnswerDto
{
    [JsonProperty("Content")]
    public string Content { get; set; } = string.Empty;

    [JsonProperty("Correct")]
    public bool Correct { get; set; }
}