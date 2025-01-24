using System.Text.Json.Serialization;

namespace Solidify.Domain.Entities.ECommerce
{
    public class Cart
    {
        public string Id { get; set; }
        public decimal TotalPrice { get; set; }
        //[JsonIgnore]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CartItem>? Items { get; set; } = new HashSet<CartItem>(); 
    }
}
