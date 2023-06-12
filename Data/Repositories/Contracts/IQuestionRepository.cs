using PPI.Models;
using PPI.Models.Dtos;

namespace PPI.Data.Repositories.Contracts;

public interface IQuestionRepository : IRepositoryBase<Question>
{
    PaginationDto<DisplayQuestionDto> GetPagedQuestions(int pageIndex, int pageSize);
}