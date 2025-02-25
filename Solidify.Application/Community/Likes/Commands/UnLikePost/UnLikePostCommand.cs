using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Community.Likes.Commands.UnLikePost
{
    public class UnLikePostCommand(int postId) : IRequest<GeneralResponseDto>
    {
        public int PostId { get; set; } = postId;
    }
}
