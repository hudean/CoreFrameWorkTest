using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.PostgreSql
{
    /// <summary>
    /// 事件总线PostgreSql选项
    /// </summary>
    public class EventBusPostgreSqlOptions
    {
        public string ConnectionString { get; set; }

        public string PublishMessageTableName { get; set; } = "EventBusPublishMessage";
    }

}
