using System.Collections.ObjectModel;
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
        Answers = new Collection<Answer>();
    }

    public Guid Id { get; private set; }
    public ESubject Subject { get; private set; }
    public EDifficulty Difficulty { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public void AddAnswer(Answer answer)
    {
        Answers?.Add(answer);
    }

    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
    }

    public virtual ICollection<Answer>? Answers { get; private set; }
}