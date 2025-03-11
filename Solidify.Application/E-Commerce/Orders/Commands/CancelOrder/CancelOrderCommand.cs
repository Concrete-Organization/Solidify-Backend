using MediatR;
using Solidify.Application.Common.Dtos;
using StackExchange.Redis;

namespace Solidify.Application.E_Commerce.Orders.Commands.CancelOrder
{
    public class CancelOrderCommand(string orderId) : IRequest<GeneralResponseDto>
    {
        public string OrderId { get; } = orderId;
    }
}
