using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.SqlServer
{
    /// <summary>
    /// 事件总线SqlServer选项
    /// </summary>
    public class EventBusSqlServerOptions
    {
        public string ConnectionString { get; set; }

        public string PublishMessageTableName { get; set; } = "EventBusPublishMessage";
    }
}
