using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Application.Files;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Enums;
using Solidify.Domain.Interfaces;

namespace Solidify.Application.Community.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler(IUnitOfWork unitOfWork,
        IFileService fileService,
        ICurrentUser currentUser) : IRequestHandler<CreatePostCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var newPost = new Post();
            if (request.ImageUris is not null)
            {
                foreach (var image in request.ImageUris)
                {
                    var uploadResult = await fileService.UploadFileAsync(image, FileType.PostImage);
                    if (!uploadResult.IsSucceeded)
                        return uploadResult;
                    newPost.ImageUris.Add(uploadResult.Model!.ToString()!);
                }
            }
            else if (String.IsNullOrEmpty(request.Content))
            {
                return GeneralResponse.CreateResponse(false, StatusCodes.Status400BadRequest, null,
                    "You must provide either an image or content");
            }
            newPost.Content = request.Content;
            newPost.UserId = currentUser.GetUserId();
            await unitOfWork.GetRepository<Post>().AddAsync(newPost);
            await unitOfWork.Commit();
            return GeneralResponse.CreateResponse(true, StatusCodes.Status204NoContent, null,
                "Post created successfully");
        }
    }
}
