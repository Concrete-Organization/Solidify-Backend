using AutoMapper;
using Solidify.Application.E_Commerce.Orders.Dtos;
using Solidify.Application.E_Commerce.Orders.Resolvers;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.Orders.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CartItem, OrderItem>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(c => c.Id));

            CreateMap<Order, GetAllOrdersDto>();

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ImageUri, opt => opt.MapFrom<OrderItemImageUriResolver>())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<Order, OrderDetailsDto>();

        }
    }
}
