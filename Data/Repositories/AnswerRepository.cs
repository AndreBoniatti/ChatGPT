using PPI.Data.Context;
using PPI.Data.Repositories.Contracts;
using PPI.Models;

namespace PPI.Data.Repositories;

public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
{
    public AnswerRepository(DataContext dataContext) : base(dataContext)
    {
    }
}