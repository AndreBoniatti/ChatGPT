using Microsoft.EntityFrameworkCore;
using PPI.Data.Context;
using PPI.Data.Repositories.Contracts;
using System.Linq.Expressions;

namespace PPI.Data.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly DataContext _dataContext;

    protected DbSet<TEntity> SetEntity() => _dataContext.Set<TEntity>();

    protected RepositoryBase(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id) => await SetEntity().FindAsync(id);
    public IEnumerable<TEntity> GetAll() => SetEntity().AsEnumerable();
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression) => SetEntity().Where(expression);
    public void Add(TEntity entity) => SetEntity().Add(entity);
    public void Update(TEntity entity) => SetEntity().Update(entity);
    public void AddRange(IEnumerable<TEntity> entities) => SetEntity().AddRange(entities);
    public void Remove(TEntity entity) => SetEntity().Remove(entity);
    public void RemoveRange(IEnumerable<TEntity> entities) => SetEntity().RemoveRange(entities);
    public int SaveChanges() => _dataContext.SaveChanges();
}
