using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.RabbitMQ
{
    /// <summary>
    /// 事件总线RabbitMq选项
    /// </summary>
    public class EventBusRabbitMqOptions
    {
        public RabbitMqPublishConfigure RabbitMqPublishConfigure { get; }
        public List<RabbitMqSubscribeConfigure> RabbitSubscribeConfigures { get; }

        public EventBusRabbitMqOptions()
        {
            RabbitMqPublishConfigure = new RabbitMqPublishConfigure();
            RabbitSubscribeConfigures = new List<RabbitMqSubscribeConfigure>();
        }

        public EventBusRabbitMqOptions AddPublishConfigure(Action<RabbitMqPublishConfigure> configureOptions = null)
        {
            if (configureOptions == null) return this;
            configureOptions.Invoke(RabbitMqPublishConfigure);
            return this;
        }

        public EventBusRabbitMqOptions AddSubscribeConfigures(Action<List<RabbitMqSubscribeConfigure>> configureOptions = null)
        {
            if (configureOptions == null) return this;
            configureOptions.Invoke(RabbitSubscribeConfigures);
            return this;
        }

    }
}
