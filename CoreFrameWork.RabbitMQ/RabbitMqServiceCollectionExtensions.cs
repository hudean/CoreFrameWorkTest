using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.RabbitMQ
{
    /// <summary>
    /// RabbitMq服务集合扩展
    /// </summary>
    public static class RabbitMqServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, Action<RabbitMqOptions> configureOptions = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddSingleton<IRabbitMqPersistentConnection, DefaultRabbitMqPersistentConnection>();
            services.AddSingleton<IRabbitMqMessageConsumerFactory, DefaultRabbitMqMessageConsumerFactory>();
            if (configureOptions != null)
                services.Configure(configureOptions);
            return services;
        }
    }
}
