using AutoMapper;
using Microsoft.AspNetCore.Http;
using Solidify.Application.E_Commerce.Reviews.Dtos;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.Reviews.Resolvers
{
    public class ReviewCompanyImageUriResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<ProductReview, ReviewDto, string?>
    {
        public string? Resolve(ProductReview source, ReviewDto destination, string? destMember, ResolutionContext context)
        {

            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            if (source.ConcreteCompany.ProfileImageUrl is not null)
                destination.ProfileImageUrl = $"{baseUri}/Uploads/ProfileImages/{source.ConcreteCompany.ProfileImageUrl}";


            return destination.ProfileImageUrl;
        }
    }
}
