namespace Solidify.Domain.Interfaces;

public interface IUnitOfWork<TEntity> where TEntity : class
{
    Task<int> Commit();
    IGenericRepository<TEntity> GetRepository(TEntity entity);
}