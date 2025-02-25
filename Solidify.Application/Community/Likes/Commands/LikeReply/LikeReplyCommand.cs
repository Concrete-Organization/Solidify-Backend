using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Community.Likes.Commands.LikeReply
{
    public class LikeReplyCommand(int replyId) : IRequest<GeneralResponseDto>
    {
        public int ReplyId { get; set; } = replyId;
    }
}
