using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery(string orderId) : IRequest<GeneralResponseDto>
    {
        public string OrderId { get; } = orderId;
    }
}
