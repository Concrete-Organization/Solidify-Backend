using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Community.Comments.Commands.CreateComment;
using Solidify.Application.Community.Comments.Dtos;

namespace Solidify.API.Controllers
{
    [Authorize]
    public class CommentController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost("{postId}")]
        public  async Task<IActionResult> PostComment(int postId, [FromBody] CreateCommentDto dto)
        {
            var command = new CreateCommentCommand()
            {
                PostId = postId,
                Content = dto.Content
            };
            return await HandleCommand(command);
        }
    }
}
