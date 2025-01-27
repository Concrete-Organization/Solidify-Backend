using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification;
using Solidify.Infrastructure.Persistance;

namespace Solidify.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(SolidifyDbContext context)
        : IGenericRepository<TEntity> where TEntity : class
    {
        public async Task<(IEnumerable<TEntity>, int)> GetAllAsync(ISpecification<TEntity> specification)
        {
            var (result, count) =  HandleQuery(specification);
            return (await result.ToListAsync(), count);
        }

        public async Task<TEntity> GetAsync(ISpecification<TEntity> specification)
        {
            var (result, count) = HandleQuery(specification);
            return await result.FirstOrDefaultAsync();
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


        private (IQueryable<TEntity>, int) HandleQuery(ISpecification<TEntity> specification)
        {
            var inputQuery = context.Set<TEntity>();
            return SpecificationsEvaluator<TEntity>.GetQuery(inputQuery, specification);
        }
    }
}
