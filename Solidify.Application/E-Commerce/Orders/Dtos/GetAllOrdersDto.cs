using Solidify.Domain.Enums;

namespace Solidify.Application.E_Commerce.Orders.Dtos
{
    public class GetAllOrdersDto
    {
        public string Id { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
