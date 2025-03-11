using Solidify.Domain.Entities.ECommerce.Companies;
using Solidify.Domain.Enums;

namespace Solidify.Domain.Entities.ECommerce
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public MeasurementUnit Measurement { get; set; }
        public string ImageUri { get; set; }
        public int? Rate { get; set; }
        public int? Discount { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public string? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        //public string? AdminId { get; set; }
        //public virtual ApplicationUser? Admin { get; set; }
        public virtual ICollection<ProductReview>? Reviews { get; set; } = new HashSet<ProductReview>();
        public void CalculateRate()
        {
            Rate = Reviews.Select(r => r.UserRate).Sum() / Reviews.Count;
        }

    }
}
