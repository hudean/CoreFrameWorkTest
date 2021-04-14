using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息处理器接口
    /// </summary>
    public interface IMessageHandler
    {
    }

    /// <summary>
    /// 消息处理器接口
    /// </summary>
    public interface IMessageHandler<in TMessage> : IMessageHandler
    where TMessage : class, IMessage
    {
        Task HandAsync(TMessage message);
    }
}
