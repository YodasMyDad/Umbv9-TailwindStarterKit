using Microsoft.Extensions.Caching.Memory;
using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Umb9.Core.Shared.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// Gets the root id of the site, cached for speed
        /// </summary>
        /// <param name="publishedContent"></param>
        /// <returns></returns>
        public int CachedRootContentId(IPublishedContent publishedContent)
        {
            // Look for cache key.
            if (!_cache.TryGetValue(Constants.CacheKeys.RootId, out int cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = publishedContent.AncestorOrSelf(1).Id;

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(Constants.CacheKeys.MemoryCacheInMinutes));

                // Save data in cache.
                _cache.Set(Constants.CacheKeys.RootId, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }
    }
}