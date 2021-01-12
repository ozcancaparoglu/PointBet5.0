using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache redisCache;

        public CacheManager(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public CacheManager(IDistributedCache redisCache)
        {
            this.redisCache = redisCache;
        }

        #region Memory Cache Methods

        public T Set<T>(string key, T t, int time)
        {
            var cacheExpirationOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(time),
                Priority = CacheItemPriority.High
            };

            memoryCache.Set(key, t, cacheExpirationOptions);

            return t;
        }    
        public TItem Get<TItem>(string key)
        {
            return memoryCache.Get<TItem>(key);
        }
        public bool TryGetValue<TItem>(string key, out TItem value)
        {
            return memoryCache.TryGetValue(key, out value);
        }

        #endregion

        #region Redis Cache Methods

        public async Task SetAsync<TITem>(string key, TITem item, int Time)
        {
            var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(Time));

            var data = JsonConvert.SerializeObject(item);
            await redisCache.SetStringAsync(key, data, option);
        }
        public async Task<TItem> GetAsync<TItem>(string key)
        {
            var data = await redisCache.GetStringAsync(key);
            return JsonConvert.DeserializeObject<TItem>(data);
        }
        public bool IsCached(string key)
        {
            return !string.IsNullOrEmpty(redisCache.GetString(key));
        }

        #endregion

        #region Common

        public void Remove(string key)
        {
            if (memoryCache != null)
                memoryCache.Remove(key);

            if (redisCache != null)
            {
                var data = redisCache.GetString(key);
                if (!string.IsNullOrWhiteSpace(data))
                    redisCache.Remove(key);
            }
        }

        #endregion
    }
}
