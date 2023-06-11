using Newtonsoft.Json;

namespace PPI.Models.Dtos;

public class QuestionsDto
{
    [JsonProperty("Questions")]
    public List<QuestionDto>? Questions { get; set; }
}

public class QuestionDto
{
    [JsonProperty("Content")]
    public string Content { get; set; } = string.Empty;

    [JsonProperty("Answers")]
    public List<AnswerDto>? Answers { get; set; }
}