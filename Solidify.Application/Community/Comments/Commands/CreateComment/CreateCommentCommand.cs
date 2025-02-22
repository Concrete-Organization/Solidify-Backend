using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Community.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<GeneralResponseDto>
    {
        public int PostId { get; set; }
        public string Content { get; set; }

    }
}
