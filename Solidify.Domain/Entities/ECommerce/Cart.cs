using System.Text.Json.Serialization;

namespace Solidify.Domain.Entities.ECommerce
{
    public class Cart
    {
        public string Id { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<CartItem>? Items { get; set; } = new HashSet<CartItem>(); 
    }
}
