using System;
using System.Runtime.Caching;

namespace Rbi.Infrastructure.Caching
{
    public class DotNetMemoryCache : ICache<CacheItemPolicy>
    {
        public bool Add(string key, object value, CacheItemPolicy cacheItemPolicy)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (cacheItemPolicy == null)
            {
                throw new ArgumentNullException("cacheItemPolicy");
            }
            if (value is IDisposable)
            {
                throw new ArgumentException("caching of disposable objects not supported");
            }

            return MemoryCache.Default.Add(key, value, cacheItemPolicy);
        }

        public T Get<T>(string key) where T : class { return (T) MemoryCache.Default.Get(key); }

        public object this[string key]
        {
            get { return Get<object>(key); }
        }

        public void Remove(string key) { MemoryCache.Default.Remove(key); }
    }
}