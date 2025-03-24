using AutoMapper;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Posts.Resolvers
{
    public class PostProfileImageUriResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Post, PostDto, string?>
    {
        public string? Resolve(Post source, PostDto destination, string? destMember, ResolutionContext context)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            if (source.Engineer != null &&  source.Engineer.ProfileImageUrl is not null)
                destination.ProfileImageUrl = $"{baseUri}/Uploads/Engineers/{source.Engineer.ProfileImageUrl}";


            return destination.ProfileImageUrl;
        }
    }
}
