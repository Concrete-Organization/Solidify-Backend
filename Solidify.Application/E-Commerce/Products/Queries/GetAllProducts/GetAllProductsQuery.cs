using Solidify.Application.Common.Pagination;
using Solidify.Application.E_Commerce.Products.Dtos;

namespace Solidify.Application.E_Commerce.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery: PaginatedQuery
    {
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
