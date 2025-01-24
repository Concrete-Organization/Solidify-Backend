using Solidify.Domain.Enums;

namespace Solidify.Domain.Entities.Common
{
    public class Payment
    {
        public string Id { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Amount { get; set; }
    }
}
