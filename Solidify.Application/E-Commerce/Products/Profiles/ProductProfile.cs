using AutoMapper;
using Solidify.Application.E_Commerce.Products.Commands.CreateProduct;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
