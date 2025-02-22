using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Community.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<GeneralResponseDto>
    {
        public string? Content { get; set; }
        public List<IFormFile>? ImageUris { get; set; }
    }
}
