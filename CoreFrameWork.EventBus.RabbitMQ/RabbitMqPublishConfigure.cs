using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.RabbitMQ
{
    /// <summary>
    /// RabbitMq发布配置
    /// </summary>
    public class RabbitMqPublishConfigure
    {
        public string ExchangeName { get; set; }

        public RabbitMqPublishConfigure()
        {
        }

        public string GetExchangeName()
        {
            return ExchangeName;
        }
    }
}
