using AutoMapper;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Community.Comments.Dtos;
using Solidify.Application.Community.Replies.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Replies.Resolvers
{
    public class ReplyProfileImageUriResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Reply, ReplyDto, string?>
    {
        public string? Resolve(Reply source, ReplyDto destination, string? destMember, ResolutionContext context)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            if (source.Engineer.ProfileImageUrl is not null)
                destination.ProfileImageUrl = $"{baseUri}/Uploads/Engineers/{source.Engineer.ProfileImageUrl}";


            return destination.ProfileImageUrl;
        }
    }
}
