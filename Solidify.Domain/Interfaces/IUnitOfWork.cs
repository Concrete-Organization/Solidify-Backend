namespace Solidify.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<int> Commit();
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}