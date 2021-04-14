using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息处理器生命周期特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageHandlerLifetimeAttribute : Attribute
    {
        public MessageHandlerLifetime Lifetime { get; }

        public MessageHandlerLifetimeAttribute(MessageHandlerLifetime lifetime)
        {
            Lifetime = lifetime;
        }

        public static MessageHandlerLifetime GetHandlerLifetime(Type handlerType)
        {
            if (handlerType == null)
            {
                throw new ArgumentNullException(nameof(handlerType));
            }
            return handlerType
                       .GetCustomAttributes(true)
                       .OfType<MessageHandlerLifetimeAttribute>()
                       .FirstOrDefault()
                       ?.Lifetime
                   ?? MessageHandlerLifetime.Transient;
        }
    }
}
