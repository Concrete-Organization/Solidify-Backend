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

namespace Solidify.Application.Community.Likes.Commands.UnLikePost
{
    public class UnLikePostCommandHandler(IUnitOfWork unitOfWork,
        ICurrentUser currentUser) : IRequestHandler<UnLikePostCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(UnLikePostCommand request, CancellationToken cancellationToken)
        {
            var post = await unitOfWork.GetRepository<Post>().GetAsync(new PostSpecification(request.PostId))
                       ?? throw new NotFoundException(nameof(Post), request.PostId);

            var likeRepository = unitOfWork.GetRepository<PostLike>();

            var engineerId = currentUser.GetUserId();

            var likePost = await likeRepository.GetAsync(new PostLikeSpecification(engineerId, request.PostId))
                           ?? throw new BadRequestException("Post already is not liked");

            likeRepository.Delete(likePost);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status204NoContent, null, "Post UnLiked Successfully");
        }
    }
}
