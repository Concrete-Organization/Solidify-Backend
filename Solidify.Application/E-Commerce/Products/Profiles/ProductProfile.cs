using AutoMapper;
using Microsoft.AspNetCore.Http;
using Solidify.Application.E_Commerce.Products.Commands.CreateProduct;
using Solidify.Application.E_Commerce.Products.Commands.UpdateProduct;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Application.E_Commerce.Products.Queries.GetAllProducts;
using Solidify.Application.E_Commerce.Products.Resolvers;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Specification.ProductSpecifications;

namespace Solidify.Application.E_Commerce.Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            
            CreateMap<CreateProductCommand, Product>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ImageUri,
                    op => op.MapFrom<ProductImageUriResolver>());

            CreateMap<Product, ProductDetailsDto>()
                .ForMember(dest => dest.ImageUri,
                    op => op.MapFrom<ProductDetailsImageUriResolver>())
                .ForMember(dest => dest.ReviewsCount, opt => opt.MapFrom(src => src.Reviews.Count));

            CreateMap<GetAllProductsQuery, ProductSpecificationParameters>();

            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
