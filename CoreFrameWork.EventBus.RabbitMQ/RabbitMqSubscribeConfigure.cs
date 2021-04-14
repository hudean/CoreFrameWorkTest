using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.RabbitMQ
{
    /// <summary>
    /// RabbitMq订阅配置
    /// </summary>
    public class RabbitMqSubscribeConfigure
    {
        public Type EventType { get; set; }
        public string ExchangeName { get; set; }
        public string QueueName { get; set; }

        public RabbitMqSubscribeConfigure(Type eventType, string exchangeName, string queueName)
        {
            EventType = eventType;
            ExchangeName = exchangeName;
            QueueName = queueName;
        }

        public (string exchangeName, string queueName) GetExchangeNameAndQueueName(Type eventType)
        {
            return eventType == EventType ? (ExchangeName, QueueName) : (null, null);
        }
    }
}
