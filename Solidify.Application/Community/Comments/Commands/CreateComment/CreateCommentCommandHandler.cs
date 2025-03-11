using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.PostSpecifications;

namespace Solidify.Application.Community.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler(IUnitOfWork unitOfWork,
        ICurrentUser currentUser) : IRequestHandler<CreateCommentCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await unitOfWork.GetRepository<Post>().GetAsync(new PostSpecification(request.PostId))
                ?? throw new NotFoundException(nameof(Post), request.PostId);

            var newComment = new Comment
            {
                Content = request.Content,
                PostId = request.PostId,
                EngineerId = currentUser.GetUserId()
            };
            await unitOfWork.GetRepository<Comment>().AddAsync(newComment);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status201Created, null, "Comment created successfully");
        }
    }
}
