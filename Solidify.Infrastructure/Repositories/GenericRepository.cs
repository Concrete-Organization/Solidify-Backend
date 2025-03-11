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
            var result =  HandleQuery(specification);
            return (await result.ToListAsync(), await HandleCount(specification));
        }
        
        public async Task<TEntity?> GetAsync(ISpecification<TEntity> specification)
        {
            var result = HandleQuery(specification);
            return await result.FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.AddAsync(entity);
        }
        
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Remove(entity);
        }


        private IQueryable<TEntity> HandleQuery(ISpecification<TEntity> specification)
        {
            var inputQuery = context.Set<TEntity>();
            return SpecificationsEvaluator<TEntity>.GetQuery(inputQuery, specification);
        }

        private async Task<int> HandleCount(ISpecification<TEntity> specification)
        {
            var inputQuery = context.Set<TEntity>();
            return await SpecificationsEvaluator<TEntity>.GetCount(inputQuery, specification);
        }
    }
}
