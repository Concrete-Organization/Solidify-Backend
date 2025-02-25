using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Community.Likes.Commands.UnLikeComment
{
    public class UnLikeCommentCommand(int commentId) : IRequest<GeneralResponseDto>
    {
        public int CommentId { get; set; } = commentId;
    }
}
