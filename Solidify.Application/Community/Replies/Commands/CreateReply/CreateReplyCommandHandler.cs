using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CommentSpecifications;

namespace Solidify.Application.Community.Replies.Commands.CreateReply
{
    public class CreateReplyCommandHandler(IUnitOfWork unitOfWork,
        ICurrentUser currentUser) : IRequestHandler<CreateReplyCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var comment = await unitOfWork.GetRepository<Comment>()
                              .GetAsync(new GetCommentByIdSpecification(request.CommentId))
                          ?? throw new NotFoundException(nameof(Comment), request.CommentId);

            var reply = new Reply
            {
                Content = request.Content,
                CommentId = request.CommentId,
                EngineerId = currentUser.GetUserId()
            };

            await unitOfWork.GetRepository<Reply>().AddAsync(reply);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status201Created, null, "Reply created successfully");

        }
    }
}
