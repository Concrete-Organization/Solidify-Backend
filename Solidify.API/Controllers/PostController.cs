﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Community.Posts.Commands.CreatePost;
using Solidify.Application.Community.Posts.Queries.GetAllPosts;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery]GetAllPostsQuery query)
        {
            return await HandleCommand(query);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] CreatePostCommand command)
        {
            return await HandleCommand(command);
        }
    }
}
