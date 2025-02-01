using AutoMapper;
using Solidify.Application.E_Commerce.Carts.Dtos;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.Carts.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDto>();
        }
    }
}
