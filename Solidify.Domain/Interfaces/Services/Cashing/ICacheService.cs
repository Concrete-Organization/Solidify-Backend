﻿namespace Solidify.Domain.Interfaces.Services.Cashing;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key) where T : class;
    Task<T> GetAsync<T>(string key, Func<Task<T>> factory, TimeSpan expireTime) where T : class;
    Task SetAsync<T>(string key, T value, TimeSpan expireTime) where T : class;
    Task RemoveAsync(string key);
    Task RemoveByPrefixAsync(string prefixKey);
    string GenerateCachedKeyFromRequest();
}