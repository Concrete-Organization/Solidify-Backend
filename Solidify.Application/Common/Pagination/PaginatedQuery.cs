using MediatR;
using Solidify.Domain.Enums;

namespace Solidify.Application.Common.Pagination
{
    public abstract class PaginatedQuery<TResponse> : IRequest<PagedResponse<TResponse>>
    {
        public string? SearchedPhrase { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1; 
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }
}
