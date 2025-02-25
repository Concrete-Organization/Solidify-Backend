using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Community.Likes.Commands.LikeComment;
using Solidify.Application.Community.Likes.Commands.LikePost;
using Solidify.Application.Community.Likes.Commands.LikeReply;
using Solidify.Application.Community.Likes.Commands.UnLikeComment;
using Solidify.Application.Community.Likes.Commands.UnLikePost;
using Solidify.Application.Community.Likes.Commands.UnLikeReply;

namespace Solidify.API.Controllers
{
    [Authorize]
    public class LikeController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost("post/{postId}")]
        public async Task<IActionResult> LikePost(int postId)
        {
            var result = await mediator.Send(new LikePostCommand(postId));
            return Ok(result);
        }
        
        [HttpDelete("post/{postId}")]
        public async Task<IActionResult> UnLikePost(int postId)
        {
            var result = await mediator.Send(new UnLikePostCommand(postId));
            return Ok(result);
        }

        [HttpPost("comment/{commentId}")]
        public async Task<IActionResult> LikeComment( int commentId)
        {
            var result = await mediator.Send(new LikeCommentCommand(commentId));
            return Ok(result);
        }

        [HttpDelete("comment/{commentId}")]
        public async Task<IActionResult> UnLikeComment(int commentId)
        {
            var result = await mediator.Send(new UnLikeCommentCommand(commentId));
            return Ok(result);
        }

        [HttpPost("reply/{replyId}")]
        public async Task<IActionResult> LikeReply( int replyId)
        {
            var result = await mediator.Send(new LikeReplyCommand(replyId));
            return Ok(result);
        }

        [HttpDelete("reply/{replyId}")]
        public async Task<IActionResult> UnLikeReply(int replyId)
        {
            var result = await mediator.Send(new UnLikeReplyCommand(replyId));
            return Ok(result);
        }
    }
}
