namespace Solidify.Domain.Entities.ECommerce
{
    public class ShippingDetails
    {
        public int Id { get; set; }
        public string Carrier { get; set; }
        public DateTime ShippingDate { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
