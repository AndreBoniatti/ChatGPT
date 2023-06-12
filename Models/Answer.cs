namespace PPI.Models;

public class Answer
{
    public Answer(string content, bool correct)
    {
        Content = content;
        Correct = correct;

        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public bool Correct { get; private set; }

    public Guid QuestionId { get; private set; }
    public virtual Question? Question { get; private set; }
}