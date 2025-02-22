using AutoMapper;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common.User;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Helper
{
    public class ProfileImageUriResolver<TSource, TDestination>(ICurrentUser currentUser,
        IHttpContextAccessor httpContextAccessor) : IValueResolver<TSource, TDestination, string?>
        where TDestination : EngineerInfo
    {
        public string? Resolve(TSource source, TDestination destination, string? destMember, ResolutionContext context)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            var engineer = currentUser.GetEngineer(destination.UserId).GetAwaiter().GetResult();
            if (engineer is not null)
            {
                if (engineer.ProfileImageUrl is not null)
                    destination.ProfileImageUrl = $"{baseUri}/Uploads/ProfileImages/{engineer.ProfileImageUrl}";
            }

            return destination.ProfileImageUrl;
        }
    }
}
