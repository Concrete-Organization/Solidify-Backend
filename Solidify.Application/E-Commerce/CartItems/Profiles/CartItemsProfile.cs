using AutoMapper;
using Solidify.Application.E_Commerce.CartItems.Resolvers;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.CartItems.Profiles
{
    public class CartItemsProfile : Profile
    {
        public CartItemsProfile()
        {
            CreateMap<Product, CartItem>()
                .ForMember(dest => dest.ImageUri, opt => opt.MapFrom<CartItemImageUriResolver>());
        }
    }
}
