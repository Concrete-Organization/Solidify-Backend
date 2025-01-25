using Solidify.Domain.Specification;

namespace Solidify.Domain.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(BaseSpecification<TEntity> specification);
        Task<TEntity> GetAsync(BaseSpecification<TEntity> specification);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
