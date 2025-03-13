using Solidify.Domain.Entities.Common;
using Solidify.Domain.Entities.ECommerce.Companies;

namespace Solidify.Domain.Entities.ECommerce
{
    public class ProductReview
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public int UserRate { get; set; }
        public string ConcreteCompanyId { get; set; }
        public virtual ConcreteCompany? ConcreteCompany { get; set; }
        public string ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
