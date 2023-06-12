using Microsoft.EntityFrameworkCore;
using PPI.Data.Context;
using PPI.Data.Repositories.Contracts;
using PPI.Models;
using PPI.Models.Dtos;

namespace PPI.Data.Repositories;

public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
{
    public QuestionRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public PaginationDto<DisplayQuestionDto> GetPagedQuestions(int pageIndex = 0, int pageSize = 10)
    {
        var query = _dataContext.Questions
            .AsNoTracking()
            .Include(x => x.Answers)
            .OrderByDescending(x => x.CreatedAt)
            .Where(x => x.DeletedAt == null)
            .Select(x => new DisplayQuestionDto
            {
                Id = x.Id,
                Content = x.Content,
                Subject = x.Subject,
                Difficulty = x.Difficulty,
                Answers = x.Answers!.Select(y => new AnswerDto
                {
                    Content = y.Content,
                    Correct = y.Correct
                }).ToList()
            })
            .AsQueryable();

        var pagedQuery = new PaginationDto<DisplayQuestionDto>()
        {
            Data = query.Skip(pageSize * pageIndex).Take(pageSize).ToList(),
            Count = query.Count(),
        };

        return pagedQuery;
    }
}