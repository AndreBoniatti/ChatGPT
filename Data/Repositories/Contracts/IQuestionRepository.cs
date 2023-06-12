using PPI.Models;
using PPI.Models.Dtos;
using PPI.Models.Enums;

namespace PPI.Data.Repositories.Contracts;

public interface IQuestionRepository : IRepositoryBase<Question>
{
    PaginationDto<DisplayQuestionDto> GetPagedQuestions(int pageIndex, int pageSize, string? filter, ESubject? subject, EDifficulty? difficulty);
}