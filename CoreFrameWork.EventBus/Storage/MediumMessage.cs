using CoreFrameWork.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.Storage
{
    /// <summary>
    /// 中等消息
    /// </summary>
    public class MediumMessage
    {
        public MediumMessage(IMessage aggregateRootEvent)
        {
            Id = Guid.NewGuid().ToString();
            Version = 1;
            MessageType = aggregateRootEvent.GetType().ToString();
            MessageData = aggregateRootEvent.ToJson();
            CreateTime = DateTime.Now;
            UtcTime = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public int Version { get; set; }

        public string MessageType { get; set; }

        public string MessageData { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UtcTime { get; set; }
    }
}
