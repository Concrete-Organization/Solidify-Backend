using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Entities.Community.Likes;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.PostLikeSpecifications;
using Solidify.Domain.Specification.PostSpecifications;

namespace Solidify.Application.Community.Likes.Commands.LikePost
{
    public class LikePostCommandHandler(IUnitOfWork unitOfWork,
        ICurrentUser currentUser) : IRequestHandler<LikePostCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            var post = await unitOfWork.GetRepository<Post>().GetAsync(new PostSpecification(request.PostId))
                       ?? throw new NotFoundException(nameof(Post), request.PostId);

            var likeRepository = unitOfWork.GetRepository<PostLike>();

            var engineerId = currentUser.GetUserId();

            var likePost = await likeRepository.GetAsync(new PostLikeSpecification(engineerId, request.PostId));
            if (likePost is not null)
                throw new BadRequestException("Post already liked");

            var newLike = new PostLike() { EngineerId = engineerId, PostId = request.PostId };

            await likeRepository.AddAsync(newLike);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status204NoContent, null, "Post Liked Successfully");
        }
    }
}
