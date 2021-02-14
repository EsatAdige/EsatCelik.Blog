using System;

namespace EsatCelik.Core.CacheManager
{
    public interface ICacheProvider
    {
        void ChangeDatabase(int databaseId);

        void Set<T>(string key, T value);

        void Set<T>(string key, T value, TimeSpan timeout, bool hasPrefix = true);

        T Get<T>(string key, bool hasPrefix = true);

        bool Remove(string key, bool hasPrefix = true);

        bool IsInCache(string key, bool hasPrefix = true);
    }
}
