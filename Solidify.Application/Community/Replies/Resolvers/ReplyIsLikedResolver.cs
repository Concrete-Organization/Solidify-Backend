using AutoMapper;
using Solidify.Application.Common.User;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Application.Community.Replies.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Posts.Resolvers;

public class ReplyIsLikedResolver(ICurrentUser currentUser) : IValueResolver<Reply, ReplyDto, bool>
{
    public bool Resolve(Reply source, ReplyDto destination, bool destMember, ResolutionContext context)
    {
        if (source.Likes.Any(l => l.EngineerId == currentUser.GetUserId()))
            return true;

        return false;
    }
}