using System.Text.Json.Serialization;

namespace Solidify.Domain.Entities.ECommerce
{
    public class Cart
    {
        public string Id { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<CartItem>? Items { get; set; } = new HashSet<CartItem>();

        public void GetTotalPrice()
        {
            foreach (CartItem item in this.Items!)
            {
                this.TotalPrice += (item.Price * item.Quantity);
            }
        }
    }
}
