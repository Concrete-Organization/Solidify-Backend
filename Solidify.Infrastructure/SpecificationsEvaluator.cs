using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Specification;

namespace Solidify.Infrastructure
{
    public static class SpecificationsEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IEnumerable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery as IQueryable<TEntity>;

            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            query = spec.Includes.Aggregate(query,
                (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            if (spec.SortAsc is not null)
                query = query.OrderBy(spec.SortAsc);

            if (spec.SortDesc is not null)
                query = query.OrderByDescending(spec.SortDesc);

            if (spec.IsPaginationEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            return query;
        }

        public static async Task<int> GetCount(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            return await query.CountAsync();
        }
    }
}
