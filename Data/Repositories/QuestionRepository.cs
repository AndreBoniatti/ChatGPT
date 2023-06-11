using PPI.Data.Context;
using PPI.Data.Repositories.Contracts;
using PPI.Models;

namespace PPI.Data.Repositories;

public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
{
    public QuestionRepository(DataContext dataContext) : base(dataContext)
    {
    }
}