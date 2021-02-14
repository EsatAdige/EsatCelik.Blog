using ServiceStack.Redis;
using System;
using Microsoft.Extensions.Options;

namespace EsatCelik.Core.CacheManager
{
    public class RedisCacheProvider : ICacheProvider
    {
        private readonly RedisEndpoint _endPoint;
        private readonly string _keyPrefix;

        public RedisCacheProvider(IOptions<CacheConfiguration> options)
        {
            _endPoint = new RedisEndpoint(options.Value.Host, options.Value.Port, options.Value.Password, options.Value.DatabaseId);

            _keyPrefix = options.Value.KeyPrefix;
        }

        public RedisCacheProvider(string host, int port, string password, int databaseId, string keyPrefix)
        {
            _endPoint = new RedisEndpoint(host, port, password, databaseId);

            _keyPrefix = keyPrefix;
        }

        public void ChangeDatabase(int databaseId)
        {
            _endPoint.Db = databaseId;
        }

        #region Set Cache
        public void Set<T>(string key, T value)
        {
            this.Set(key, value, TimeSpan.FromMinutes(60));
        }

        public void Set<T>(string key, T value, TimeSpan timeout, bool hasPrefix = true)
        {
            key = GetKey(key, hasPrefix);

            if (value == null)
            {
                value = (T)Activator.CreateInstance(typeof(T));
            }

            using (var client = new RedisClient(_endPoint))
            {
                client.As<T>().SetValue(key, value, timeout);
            }
        }
        #endregion

        #region Get Cache
        public T Get<T>(string key, bool hasPrefix = true)
        {
            key = GetKey(key, hasPrefix);

            T result;

            using (var client = new RedisClient(_endPoint))
            {
                var wrapper = client.As<T>();

                result = wrapper.GetValue(key);
            }

            return result;
        }
        #endregion

        #region Remove Cache
        public bool Remove(string key, bool hasPrefix = true)
        {
            key = GetKey(key, hasPrefix);

            bool removed;

            using (var client = new RedisClient(_endPoint))
            {
                removed = client.Remove(key);
            }

            return removed;
        }
        #endregion

        #region Has Cached
        public bool IsInCache(string key, bool hasPrefix = true)
        {
            key = GetKey(key, hasPrefix);

            bool isInCache;

            using (var client = new RedisClient(_endPoint))
            {
                isInCache = client.ContainsKey(key);
            }

            return isInCache;
        }
        #endregion

        private string GetKey(string key, bool hasPrefix)
        {
            return hasPrefix ? $"{_keyPrefix}_{key}" : key;
        }
    }
}
