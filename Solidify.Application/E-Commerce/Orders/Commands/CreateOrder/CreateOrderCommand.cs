using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand(string userId) : IRequest<GeneralResponseDto>
    {
        public string UserId { get; } = userId;
    }
}
