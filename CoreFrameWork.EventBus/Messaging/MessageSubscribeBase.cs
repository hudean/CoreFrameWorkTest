using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息订阅基础
    /// </summary>
    public abstract class MessageSubscribeBase : IMessageSubscribe
    {
        public void Initialize(params Assembly[] assemblies)
        {
            var handlerTypes = MessageHandlerExtensions.GetHandlerTypes(assemblies);
            foreach (var handlerType in handlerTypes)
            {
                var baseHandlerTypes = MessageHandlerExtensions.GetBaseHandlerTypes(handlerType);
                foreach (var baseHandlerType in baseHandlerTypes)
                {
                    var messageType = baseHandlerType.GenericTypeArguments.Single();
                    Subscribe(messageType, handlerType);
                }
            }
        }

        protected abstract void Subscribe(Type messageType, Type handlerType);

        public abstract void Subscribe<T, TH>()
            where T : class, IMessage
            where TH : IMessageHandler<T>, new();

        public abstract void UnSubscribe<T, TH>()
            where T : class, IMessage
            where TH : IMessageHandler<T>, new();

    }
}
