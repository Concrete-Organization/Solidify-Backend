using Microsoft.EntityFrameworkCore;
using Solidify.Application.Specifications;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Infrastructure
{
    public static class SpecificationsEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, BaseSpecification<TEntity> spec)
        {
            var query = inputQuery;
            
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            query = spec.Includes.Aggregate(query,
                (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            if (spec.SortAsc is not null)
                query = query.OrderBy(spec.SortAsc);

            if (spec.SortDesc is not null)
                query = query.OrderByDescending(spec.SortDesc);

            if (spec.IsPaginationEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);

            return query;
        }
    }
}
