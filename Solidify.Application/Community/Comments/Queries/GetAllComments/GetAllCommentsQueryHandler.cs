using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.Community.Comments.Dtos;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CommentSpecifications;
using Solidify.Domain.Specification.PostSpecifications;

namespace Solidify.Application.Community.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<GetAllCommentsQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var post = await unitOfWork.GetRepository<Post>().GetAsync(new PostSpecification(request.PostId))
                ?? throw new NotFoundException(nameof(Post), request.PostId);

            var (comments, count) = await unitOfWork.GetRepository<Comment>().GetAllAsync(new CommentSpecification(request.PostId));
            var commentsDto = mapper.Map<IEnumerable<CommentDto>>(comments);

            return GeneralResponse.CreateResponse(
                true,
                StatusCodes.Status200OK,
                new PagedResponse<CommentDto>(commentsDto, request.PageSize, request.PageNumber, count),
                "");
        }
    }
}
