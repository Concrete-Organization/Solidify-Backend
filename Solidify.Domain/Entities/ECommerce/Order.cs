using Solidify.Domain.Entities.ECommerce.Companies;
using Solidify.Domain.Enums;

namespace Solidify.Domain.Entities.ECommerce
{
    public class Order
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public virtual ICollection<OrderItem>? Items { get; set; } = new HashSet<OrderItem>();
        public virtual ICollection<ShippingDetails>? ShippingDetails { get; set; } = new HashSet<ShippingDetails>();
        public virtual ICollection<CompanySales>? CompanySales { get; set; } = new HashSet<CompanySales>();
    }
}
