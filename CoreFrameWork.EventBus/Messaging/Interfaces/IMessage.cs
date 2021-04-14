using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息接口
    /// </summary>
    public interface IMessage
    {
        string Id { get; set; }

        DateTime Timestamp { get; set; }

        IDictionary<string, string> Items { get; }

        void AddItems(IDictionary<string, string> items);

        void RemoveItem(string itemKey);
    }
}
