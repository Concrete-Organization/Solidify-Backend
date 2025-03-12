using Solidify.Application.E_Commerce.Reviews.Dtos;
using Solidify.Domain.Enums;

namespace Solidify.Application.E_Commerce.Products.Dtos
{
    public class ProductDetailsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public MeasurementUnit Measurement { get; set; }
        public string ImageUri { get; set; }
        public int Rate { get; set; }
        public int Discount { get; set; }
        public string BrandName { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public int ReviewsCount { get; set; }
    }
}
