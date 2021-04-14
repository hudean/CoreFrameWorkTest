using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.RabbitMQ
{
    /// <summary>
    /// RabbitMq常量
    /// </summary>
    public static class RabbitMqConst
    {
        public const string DefaultExchangeName = "event_bus_rabbitmq_default_exchange";
        public const string DefaultQueueName = "event_bus_rabbitmq_default_queue";
    }
}
