namespace Solidify.Domain.Entities.ECommerce
{
    public class CartItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
        public string ImageUri { get; set; }

        public void IncrementQuantity() => this.Quantity++;
        public void DecrementQuantity() => this.Quantity--;
        
    }
}
