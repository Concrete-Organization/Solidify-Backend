using AutoMapper;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Posts.Resolvers
{
    public class PostImagesUriResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Post, PostDto, List<string>>
    {
        public List<string> Resolve(Post source, PostDto destination, List<string> destMember, ResolutionContext context)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            return source.ImageUris.Any()
                ? source.ImageUris.Select(uri => $"{baseUri}/Uploads/PostImages/{uri}").ToList()
                : [];
        }
    }
}
