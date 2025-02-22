using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.PostSpecifications;

namespace Solidify.Application.Community.Posts.Queries.GetAllPosts
{
    public class GetAllPostsQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<GetAllPostsQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var (posts, count) = await unitOfWork.GetRepository<Post>().GetAllAsync(new PostSpecification(mapper.Map<PostSpecificationParameters>(request)));

            return GeneralResponse.CreateResponse(
                true, 
                StatusCodes.Status200OK, 
                new PagedResponse<PostDto>(mapper.Map<IEnumerable<PostDto>>(posts), request.PageSize, request.PageNumber, count),
                "");
        }
    }
}
