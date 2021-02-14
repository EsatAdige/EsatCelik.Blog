using System;
using Microsoft.Extensions.DependencyInjection;

namespace EsatCelik.Core.CacheManager
{
    public static class CacheExtensions
    {
        public static IServiceCollection AddCacheProvider(this IServiceCollection serviceCollection, Action<CacheConfiguration> options)
        {
            serviceCollection.AddScoped<ICacheProvider, RedisCacheProvider>();
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), @"Please provide options for CacheProvider.");
            }
            serviceCollection.Configure(options);
            return serviceCollection;
        }
    }
}
