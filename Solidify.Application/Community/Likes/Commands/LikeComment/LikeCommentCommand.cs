using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Community.Likes.Commands.LikeComment
{
    public class LikeCommentCommand(int commentId) : IRequest<GeneralResponseDto>
    {
        public int CommentId { get; set; } = commentId;
    }
}
