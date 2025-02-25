using Solidify.Domain.Enums;

namespace Solidify.Application.E_Commerce.Products.Dtos
{
    public class ProductDto
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

    }
}
