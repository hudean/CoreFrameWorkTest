using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.RabbitMQ
{
    public class RabbitMqOptions
    {
        public RabbitMqConnectionConfigure Connection { get; set; }

        public RabbitMqOptions()
        {
            Connection = new RabbitMqConnectionConfigure();
        }
    }
}
