using AutoMapper;
using Microsoft.AspNetCore.Http;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.CartItems.Resolvers
{
    public class CartItemImageUriResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Product, CartItem, string>
    {
        public string Resolve(Product source, CartItem destination, string destMember, ResolutionContext context)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            return string.IsNullOrEmpty(source.ImageUri)
                ? string.Empty
                : $"{baseUri}/Uploads/ProductImages/{source.ImageUri}";

        }
    }
}
