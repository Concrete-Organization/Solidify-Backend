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
using Solidify.Domain.Specification.ReplyLikeSpecifications;
using Solidify.Domain.Specification.ReplySpecifications;

namespace Solidify.Application.Community.Likes.Commands.LikeReply
{
    public class LikeReplyCommandHandler(IUnitOfWork unitOfWork,
        ICurrentUser currentUser) : IRequestHandler<LikeReplyCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(LikeReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await unitOfWork.GetRepository<Reply>().GetAsync(new ReplySpecification(request.ReplyId))
                       ?? throw new NotFoundException(nameof(Post), request.ReplyId);

            var likeRepository = unitOfWork.GetRepository<ReplyLike>();

            var engineerId = currentUser.GetUserId();

            var likeReply = await likeRepository.GetAsync(new ReplyLikeSpecification(engineerId, request.ReplyId));
            if (likeReply is not null)
                throw new BadRequestException("Reply is already liked");

            var newLike = new ReplyLike() { EngineerId = engineerId, ReplyId = request.ReplyId };

            await likeRepository.AddAsync(newLike);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status204NoContent, null, "Reply Liked Successfully");

        }
    }
}
