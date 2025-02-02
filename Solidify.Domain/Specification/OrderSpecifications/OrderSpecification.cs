using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Domain.Specification.OrderSpecifications
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification(string userId, int pageSize, int pageNumber) : base(o => o.UserId == userId)
        {
            AddPagination(pageSize, (pageNumber - 1) * pageSize);
        }
    }
}
