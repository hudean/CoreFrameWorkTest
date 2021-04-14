using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.RabbitMQ
{

    /// <summary>
    /// 事件总线RabbitMq服务集合扩展
    /// </summary>
    public static class EventBusRabbitMqServiceCollectionExtensions
    {
        public static EventBusBuilder AddRabbitMq(this EventBusBuilder builder, Action<EventBusRabbitMqOptions> options = null)
        {
            builder.Service.AddSingleton<IMessagePublisher, RabbitMqMessagePublisher>();
            builder.Service.AddSingleton<IMessageSubscribe, RabbitMqMessageSubscribe>();
            if (options == null) return builder;
            builder.Service.Configure(options);
            return builder;
        }
    }
}
