using MediatR;
using Solidify.Application.Common.Pagination;

namespace Solidify.Application.E_Commerce.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : PaginatedQuery
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
