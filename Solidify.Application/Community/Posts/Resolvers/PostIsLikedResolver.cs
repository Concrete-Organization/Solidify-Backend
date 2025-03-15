using AutoMapper;
using Solidify.Application.Common.User;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Posts.Resolvers;

public class PostIsLikedResolver(ICurrentUser currentUser) : IValueResolver<Post, PostDto, bool>
{
    public bool Resolve(Post source, PostDto destination, bool destMember, ResolutionContext context)
    {
        if (source.Likes.Any(l => l.EngineerId == currentUser.GetUserId()))
            return true;

        return false;
    }
}