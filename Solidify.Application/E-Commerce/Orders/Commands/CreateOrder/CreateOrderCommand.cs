using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<GeneralResponseDto>
    {
        public int ShippingAddressId { get; set; }
    }
}
