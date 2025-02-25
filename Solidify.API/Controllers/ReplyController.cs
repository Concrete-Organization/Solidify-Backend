using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Community.Replies.Commands.CreateReply;
using Solidify.Application.Community.Replies.Dtos;

namespace Solidify.API.Controllers
{

    public class ReplyController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost("{commentId}")]
        public async Task<IActionResult> PostComment(int commentId, [FromBody] CreateReplyDto dto)
        {
            var command = new CreateReplyCommand()
            {
                CommentId = commentId,
                Content = dto.Content
            };
            return await HandleCommand(command);
        }

    }
}
