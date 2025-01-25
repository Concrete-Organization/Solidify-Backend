using System.Linq.Expressions;

namespace Solidify.Domain.Specification
{
    public abstract class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>>? Criteria { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; private set; } = new();

        public Expression<Func<TEntity, object>>? SortAsc { get; private set; }
        public Expression<Func<TEntity, object>>? SortDesc { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginationEnabled { get; private set; }

        protected void AddIncludes(Expression<Func<TEntity, object>> includeExpression) =>
            Includes.Add(includeExpression);

        protected void AddSortAsc(Expression<Func<TEntity, object>> sortExpression) => SortAsc = sortExpression;
        protected void AddSortDesc(Expression<Func<TEntity, object>> sortExpression) => SortDesc = sortExpression;

        protected void AddPagination(int take, int skip)
        {
            IsPaginationEnabled = true;
            Take = take;
            Skip = skip;
        }
    }
}
