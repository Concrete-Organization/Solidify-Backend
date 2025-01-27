namespace Solidify.Application.Common.Pagination;

public class PagedResponse<TResponse>
{
    public PagedResponse(IEnumerable<TResponse> items, int pageSize, int pageNumber, int itemsCount)
    {
        Items = items;
        ItemsCount = itemsCount;
        ItemsFrom = (pageNumber - 1) * pageSize + 1;
        ItemsTo = pageNumber * pageSize;
        TotalPages = (int)Math.Ceiling(itemsCount / (decimal)pageSize);
    }
    public IEnumerable<TResponse> Items { get; set; }
    public int ItemsCount { get; set; }
    public int ItemsFrom { get; set; }
    public int ItemsTo { get; set; }
    public int TotalPages { get; set; }
}