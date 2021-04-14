using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息处理器包装接口
    /// </summary>
    public interface IMessageHandlerWrapper
    {
        IMessageHandler Handler { get; }

        Type HandlerType { get; }

        Type BaseHandlerType { get; }

        int HandlerPriority { get; }
    }
}
