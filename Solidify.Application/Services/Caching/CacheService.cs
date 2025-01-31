using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Solidify.Domain.Interfaces.Services.Cashing;

namespace Solidify.Application.Services.Caching
{
    public class CacheService(IDistributedCache distributedCache,
        IHttpContextAccessor httpContextAccessor) : ICacheService
    {
        private static readonly Dictionary<string, bool> CachedKeys = new();
        public async Task<T?> GetAsync<T>(string key) where T: class
        {
            var value = await distributedCache.GetStringAsync(key);

            if (String.IsNullOrEmpty(value))
                return default;

            return JsonSerializer.Deserialize<T>(value);
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> factory) where T : class
        {
            T? value = await GetAsync<T>(key);

            if (value is not null)
                return value;

            value = await factory();

            await SetAsync(key, value);

            return value;
        }

        public async Task SetAsync<T>(string key, T value) where T : class
        {
            if (value is null)
                return;

            CachedKeys.Add(key, true);

            var stringValue = JsonSerializer.Serialize(value);

            DistributedCacheEntryOptions options = new()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };
            await distributedCache.SetStringAsync(key, stringValue, options);
        }

        public async Task RemoveAsync(string key)
        {
            await distributedCache.RemoveAsync(key);

            CachedKeys.Remove(key);
        }

        public async Task RemoveByPrefixAsync(string prefixKey)
        {
            var tasks =
                CachedKeys.Keys
                    .Where(k => k.Contains(prefixKey))
                    .Select(RemoveAsync);

            await Task.WhenAll(tasks);
        }

        public string GenerateCachedKeyFromRequest()
        {
            var request = httpContextAccessor.HttpContext!.Request;

            var cashedKey = new StringBuilder(request.Path);
            foreach (var (key, value) in request.Query.OrderBy(k => k.Key))
            {
                cashedKey.Append($"|{key}-{value}");
            }

            return cashedKey.ToString();
        }
    }
}
