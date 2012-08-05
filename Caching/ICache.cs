using System;

namespace Rbi.Infrastructure.Caching
{
    public interface ICache<in TCachingPolicy> where TCachingPolicy : class
    {
        bool Add(string key, object value, TCachingPolicy cachingPolicy);

        T Get<T>(string key) where T : class;

        Object this[string key] { get; }

        void Remove(string key);
    }
}
