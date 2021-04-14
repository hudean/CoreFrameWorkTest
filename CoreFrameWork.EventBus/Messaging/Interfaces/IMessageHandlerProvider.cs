using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息处理器提供商接口
    /// </summary>
    public interface IMessageHandlerProvider
    {
        IEnumerable<IMessageHandler> GetHandlers<TMessage>()
            where TMessage : class, IMessage;

        IEnumerable<IMessageHandler> GetHandlers(Type messageType);
    }
}
