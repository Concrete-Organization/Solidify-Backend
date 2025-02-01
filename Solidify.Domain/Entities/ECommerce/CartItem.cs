namespace Solidify.Domain.Entities.ECommerce
{
    public class CartItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageUri { get; set; }
    }
}
