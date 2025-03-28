using AutoMapper;
using Solidify.Application.E_Commerce.Orders.Dtos;
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

            CreateMap<OrderItem, OrderItemDto>();

            CreateMap<Order, OrderDetailsDto>();

        }
    }
}
