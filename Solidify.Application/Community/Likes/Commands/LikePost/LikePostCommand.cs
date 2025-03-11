using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Community.Likes.Commands.LikePost
{
    public class LikePostCommand(int postId) : IRequest<GeneralResponseDto>
    {
        public int PostId { get; set; } = postId;
    }
}
