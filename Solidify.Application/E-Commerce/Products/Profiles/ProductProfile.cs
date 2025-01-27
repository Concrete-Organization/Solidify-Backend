using AutoMapper;
using Solidify.Application.E_Commerce.Products.Commands.CreateProduct;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Application.E_Commerce.Products.Queries.GetAllProducts;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Specification.ProductSpecifications;

namespace Solidify.Application.E_Commerce.Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<GetAllProductsQuery, ProductSpecificationParameters>();
            CreateMap<IEnumerable<ProductDto>, IEnumerable<Product>>();
        }
    }
}
