namespace Solidify.Domain.Entities.ECommerce
{
    public class OrderItem
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
