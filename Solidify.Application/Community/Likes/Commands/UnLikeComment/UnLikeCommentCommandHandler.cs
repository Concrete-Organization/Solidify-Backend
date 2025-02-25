using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Application.Community.Likes.Commands.UnLikePost;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Entities.Community.Likes;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CommentLikeSpecifications;
using Solidify.Domain.Specification.CommentSpecifications;
using Solidify.Domain.Specification.PostLikeSpecifications;

namespace Solidify.Application.Community.Likes.Commands.UnLikeComment
{
    public class UnLikeCommentCommandHandler(IUnitOfWork unitOfWork,
        ICurrentUser currentUser) : IRequestHandler<UnLikeCommentCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(UnLikeCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(new GetCommentByIdSpecification(request.CommentId))
                          ?? throw new NotFoundException(nameof(Comment), request.CommentId);

            var likeRepository = unitOfWork.GetRepository<CommentLike>();

            var engineerId = currentUser.GetUserId();

            var likeComment = await likeRepository.GetAsync(new CommentLikeSpecification(request.CommentId))
                           ?? throw new BadRequestException("Comment already is not liked");

            likeRepository.Delete(likeComment);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status204NoContent, null, "Comment UnLiked Successfully");
        }
    }
}
