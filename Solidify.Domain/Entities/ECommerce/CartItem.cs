namespace Solidify.Domain.Entities.ECommerce
{
    public class CartItem
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
