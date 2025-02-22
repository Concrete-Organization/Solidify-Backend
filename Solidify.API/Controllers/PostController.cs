using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Community.Posts.Commands.CreatePost;

namespace Solidify.API.Controllers
{
    [Authorize]
    public class PostController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] CreatePostCommand command)
        {
            return await HandleCommand(command);
        }
    }
}
