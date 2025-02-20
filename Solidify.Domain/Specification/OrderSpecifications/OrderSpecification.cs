using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;

namespace Solidify.Domain.Specification.OrderSpecifications
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification(string userId, IEnumerable<OrderStatus>? orderStatus, int pageSize, int pageNumber)
            : base(o => o.UserId == userId
            && (orderStatus == null || orderStatus.Contains(o.OrderStatus)))
        {
            AddPagination(pageSize, (pageNumber - 1) * pageSize);
        }

        public OrderSpecification(string orderId): base(o => o.Id == orderId)
        {
            AddIncludes(o => o.Items);
            AddIncludes(o => o.ShippingAddress);
        }
    }
}
