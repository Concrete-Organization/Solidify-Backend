using AutoMapper;
using Solidify.Application.E_Commerce.ShippingAddresses.Commands;
using Solidify.Application.E_Commerce.ShippingAddresses.Dtos;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.ShippingAddresses.Profiles
{
    public class ShippingAddressProfile : Profile
    {
        public ShippingAddressProfile()
        {
            CreateMap<CreateShippingAddressCommand, ShippingAddress>();
            CreateMap<ShippingAddress, ShippingAddressDto>();
        }
    }
}
