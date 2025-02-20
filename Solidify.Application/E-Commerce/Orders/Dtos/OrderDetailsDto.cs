using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;

namespace Solidify.Application.E_Commerce.Orders.Dtos
{
    public class OrderDetailsDto
    {
        public string Id { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public ShippingAddressDto ShippingAddress { get; set; }
    }
}
