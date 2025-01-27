using Solidify.Domain.Entities.Common;

namespace Solidify.Domain.Entities.ECommerce
{
    public class OrderPayment : Payment
    {
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
