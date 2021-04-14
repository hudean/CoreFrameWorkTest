using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.Mysql
{
    public class EventBusMysqlOptions
    {
        public string ConnectionString { get; set; }

        public string PublishMessageTableName { get; set; } = "EventBusPublishMessage";
    }
}
