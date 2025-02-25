using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Entities.Community.Likes;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CommentLikeSpecifications;
using Solidify.Domain.Specification.CommentSpecifications;
using Solidify.Domain.Specification.PostLikeSpecifications;
using Solidify.Domain.Specification.PostSpecifications;

namespace Solidify.Application.Community.Likes.Commands.LikeComment
{
    public class LikePostCommandHandler(IUnitOfWork unitOfWork,
        ICurrentUser currentUser) : IRequestHandler<LikeCommentCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(LikeCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(new GetCommentByIdSpecification(request.CommentId))
                       ?? throw new NotFoundException(nameof(Comment), request.CommentId);

            var likeRepository = unitOfWork.GetRepository<CommentLike>();

            var engineerId = currentUser.GetUserId();

            var likeComment = await likeRepository.GetAsync(new CommentLikeSpecification(engineerId, request.CommentId));
            if (likeComment is not null)
                throw new BadRequestException("Comment already liked");

            var newLike = new CommentLike() { EngineerId = engineerId, CommentId = request.CommentId };

            await likeRepository.AddAsync(newLike);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status204NoContent, null, "Comment Liked Successfully");
        }
    }
}
