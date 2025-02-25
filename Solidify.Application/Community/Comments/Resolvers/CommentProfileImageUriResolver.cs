using AutoMapper;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Community.Comments.Dtos;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Comments.Resolvers
{
    public class CommentProfileImageUriResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Comment, CommentDto, string?>
    {
        public string? Resolve(Comment source, CommentDto destination, string? destMember, ResolutionContext context)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            if (source.Engineer.ProfileImageUrl is not null)
                destination.ProfileImageUrl = $"{baseUri}/Uploads/ProfileImages/{source.Engineer.ProfileImageUrl}";


            return destination.ProfileImageUrl;
        }
    }
}
