using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Application.Community.Likes.Commands.UnLikeComment;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Entities.Community.Likes;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CommentLikeSpecifications;
using Solidify.Domain.Specification.CommentSpecifications;
using Solidify.Domain.Specification.ReplyLikeSpecifications;
using Solidify.Domain.Specification.ReplySpecifications;

namespace Solidify.Application.Community.Likes.Commands.UnLikeReply
{
    public class UnLikeReplyCommandHandler(IUnitOfWork unitOfWork,
        ICurrentUser currentUser) : IRequestHandler<UnLikeReplyCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(UnLikeReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await unitOfWork.GetRepository<Reply>().GetAsync(new ReplySpecification(request.ReplyId))
                        ?? throw new NotFoundException(nameof(Post), request.ReplyId);

            var likeRepository = unitOfWork.GetRepository<ReplyLike>();

            var engineerId = currentUser.GetUserId();

            var likeReply = await likeRepository.GetAsync(new ReplyLikeSpecification(engineerId, request.ReplyId))
                           ?? throw new BadRequestException("Reply already is not liked");

            likeRepository.Delete(likeReply);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status204NoContent, null, "Reply UnLiked Successfully");
        }
    }
}
