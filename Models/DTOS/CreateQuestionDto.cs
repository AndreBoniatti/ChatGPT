using PPI.Models.Enums;

namespace PPI.Models.Dtos;

public class CreateQuestionsDto
{
    public List<QuestionDto>? Questions { get; set; }
    public ESubject Subject { get; set; }
    public EDifficulty Difficulty { get; set; }
}