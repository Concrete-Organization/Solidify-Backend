using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Orders.Dtos;
using Solidify.Application.E_Commerce.ShippingAddresses.Dtos;

namespace Solidify.Application.E_Commerce.ShippingAddresses.Commands
{
    public class CreateShippingAddressCommand : ShippingAddressDto, IRequest<GeneralResponseDto>
    {
    }
}
