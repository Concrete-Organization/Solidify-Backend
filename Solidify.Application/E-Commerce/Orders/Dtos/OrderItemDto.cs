namespace Solidify.Application.E_Commerce.Orders.Dtos
{
    public class OrderItemDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
