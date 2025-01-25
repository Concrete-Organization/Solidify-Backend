using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification;
using Solidify.Infrastructure.Persistance;

namespace Solidify.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(SolidifyDbContext context)
        : IGenericRepository<TEntity> where TEntity : class
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(BaseSpecification<TEntity> specification)
        {
            return await HandleQuery(specification).ToListAsync();
        }

        public async Task<TEntity> GetAsync(BaseSpecification<TEntity> specification)
        {
            return await HandleQuery(specification).FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Remove(entity);
        }


        private IQueryable<TEntity> HandleQuery(BaseSpecification<TEntity> specification)
        {
            var inputQuery = context.Set<TEntity>();
            return SpecificationsEvaluator<TEntity>.GetQuery(inputQuery, specification);
        }
    }
}
