using PPI.Models.Enums;

namespace PPI.Models.Dtos;

public class DisplayQuestionDto
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public ESubject Subject { get; set; }
    public EDifficulty Difficulty { get; set; }
    public List<AnswerDto>? Answers { get; set; }
}