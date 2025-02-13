using System.ComponentModel.DataAnnotations.Schema;

namespace Solidify.Domain.Entities.ECommerce
{
    public class ShippingDetails
    {
        public int Id { get; set; }
        public string Carrier { get; set; }
        public DateTime ShippingDate { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("ShippingAddress")]
        public int AddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
    }
}
