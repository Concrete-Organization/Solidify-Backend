using Solidify.Domain.Enums;

namespace Solidify.Domain.Specification.ProductSpecifications
{
    public class ProductSpecificationParameters
    {
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SearchedPhrase { get; set; }
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; } 
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
