using MediatR;
using Solidify.Application.Common.Pagination;

namespace Solidify.Application.E_Commerce.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : PaginatedQuery
    {
        public bool ActiveOrders { get; set; }
    }
}
