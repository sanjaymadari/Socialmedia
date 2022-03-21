using Microsoft.Extensions.Caching.Memory;

namespace Socialmedia;

public static class CacheModel
{
    private static IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

    public static void Add(string cacheKey, int value)
    {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(200),
        
            };

            _memoryCache.Set(cacheKey, value, cacheEntryOptions);
    }
    public static int Get(string cacheKey)
    {
        var result = _memoryCache.Get(cacheKey);
        return Convert.ToInt32(result);
    }

    public static void Delete(string cacheKey)
    {
        _memoryCache.Remove(cacheKey);
    }


}