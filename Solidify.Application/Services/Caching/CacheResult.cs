namespace Solidify.Application.Services.Caching;

public class CacheResult<T>
{
    public T Data { get; set; }
    public int Count { get; set; }
}