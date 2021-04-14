using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Redis
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class HttpClientServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, Action<RedisCacheOptions> options = null)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            services.TryAddSingleton(typeof(IRedisCache), typeof(StackExchangeRedis));
            if (options != null)
                services.Configure(options);
            return services;
        }
    }
}
