using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Community.Likes.Commands.UnLikeReply
{
    public class UnLikeReplyCommand(int replyId) : IRequest<GeneralResponseDto>
    {
        public int ReplyId { get; set; } = replyId;
    }
}
