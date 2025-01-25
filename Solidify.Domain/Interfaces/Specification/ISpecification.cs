using System.Linq.Expressions;

namespace Solidify.Domain.Interfaces.Specification
{
    public interface ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; }
        public List<Expression<Func<TEntity, object>>> Includes { get; }
        public Expression<Func<TEntity, object>> SortAsc { get; }
        public Expression<Func<TEntity, object>> SortDesc { get; }
        public int Take { get; }
        public int Skip { get; }
        public bool IsPaginationEnabled { get; }
    }
}
