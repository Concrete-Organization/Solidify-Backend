using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Specification;

namespace Solidify.Infrastructure
{
    public static class SpecificationsEvaluator<TEntity> where TEntity : class
    {
        public static (IQueryable<TEntity>, int) GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            int totalCount = 0;

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
                totalCount = query.Count();
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            return (query, totalCount);
        }
    }
}
