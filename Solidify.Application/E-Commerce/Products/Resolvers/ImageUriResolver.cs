using AutoMapper;
using Microsoft.AspNetCore.Http;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.Products.Resolvers
{
    public class ProductImageUriResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            return string.IsNullOrEmpty(source.ImageUri)
                ? string.Empty
                : $"{baseUri}/Uploads/ProductImages/{source.ImageUri}";
        }
    }
}
