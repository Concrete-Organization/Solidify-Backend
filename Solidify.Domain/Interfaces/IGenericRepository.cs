using Solidify.Domain.Specification;

namespace Solidify.Domain.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task<(IEnumerable<TEntity>, int)> GetAllAsync(ISpecification<TEntity> specification);
        Task<TEntity?> GetAsync(ISpecification<TEntity> specification);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
