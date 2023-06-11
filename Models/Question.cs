using PPI.Models.Enums;

namespace PPI.Models;

public class Question
{
    public Question(ESubject subject, EDifficulty difficulty, string content)
    {
        Subject = subject;
        Difficulty = difficulty;
        Content = content;

        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public ESubject Subject { get; private set; }
    public EDifficulty Difficulty { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public virtual ICollection<Answer>? Answers { get; set; }
}