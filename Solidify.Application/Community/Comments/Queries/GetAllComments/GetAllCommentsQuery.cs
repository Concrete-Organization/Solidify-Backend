using MediatR;
using Solidify.Application.Common.Pagination;

namespace Solidify.Application.Community.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQuery(int postId) : PaginatedQuery
    {
        public int PostId { get; set; } = postId;
    }
}
