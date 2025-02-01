using AutoMapper;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.CartItems.Profiles
{
    public class CartItemsProfile : Profile
    {
        public CartItemsProfile()
        {
            CreateMap<Product, CartItem>();
        }
    }
}
