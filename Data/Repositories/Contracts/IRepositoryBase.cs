using System.Linq.Expressions;

namespace PPI.Data.Repositories.Contracts;

public interface IRepositoryBase<TEntity>
{
    public Task<TEntity?> GetByIdAsync(Guid id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    int SaveChanges();
}