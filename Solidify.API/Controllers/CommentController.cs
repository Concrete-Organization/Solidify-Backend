using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Common.Pagination;
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
        public async Task<IActionResult> GetAllComments(int postId, [FromQuery]PaginatedQuery paginatedQuery)
        {
            var query = new GetAllCommentsQuery(postId)
            {
                SearchedPhrase = paginatedQuery.SearchedPhrase, PageSize = paginatedQuery.PageSize,
                PageNumber = paginatedQuery.PageNumber
            };
            return await HandleCommand(query);
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
