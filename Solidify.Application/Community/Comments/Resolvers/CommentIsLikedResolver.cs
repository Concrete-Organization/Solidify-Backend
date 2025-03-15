using AutoMapper;
using Solidify.Application.Common.User;
using Solidify.Application.Community.Comments.Dtos;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Posts.Resolvers;

public class CommentIsLikedResolver(ICurrentUser currentUser) : IValueResolver<Comment, CommentDto, bool>
{
    public bool Resolve(Comment source, CommentDto destination, bool destMember, ResolutionContext context)
    {
        if (source.Likes.Any(l => l.EngineerId == currentUser.GetUserId()))
            return true;

        return false;
    }
}