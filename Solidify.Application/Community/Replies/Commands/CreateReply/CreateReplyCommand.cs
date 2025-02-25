using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Community.Replies.Commands.CreateReply
{
    public class CreateReplyCommand: IRequest<GeneralResponseDto>
    {
        public int CommentId { get; set; } 
        public string Content { get; set; }
    }
}
