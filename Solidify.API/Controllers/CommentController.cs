using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Community.Comments.Commands.CreateComment;
using Solidify.Application.Community.Comments.Dtos;
using Solidify.Application.Community.Comments.Queries.GetAllComments;

namespace Solidify.API.Controllers
{
    [Authorize]
    public class CommentController(IMediator mediator) : BaseController(mediator)
    {
        [AllowAnonymous]
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetAllComments(int postId)
        {
            return await HandleCommand(new GetAllCommentsQuery(postId));
        }

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
