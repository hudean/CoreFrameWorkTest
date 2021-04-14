using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息处理器管理接口
    /// </summary>
    public interface IMessageHandlerManager
    {
        /// <summary>
        /// 事件移除
        /// </summary>
        event EventHandler<Type> OnEventRemoved;

        /// <summary>
        /// 消息处理程序听写
        /// </summary>
        IDictionary<Type, IList<IMessageHandlerWrapper>> MessageHandlerDict { get; }

        /// <summary>
        /// 消息类型映射听写
        /// </summary>
        IDictionary<string, Type> MessageTypeMappingDict { get; }

        /// <summary>
        /// 添加处理器
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="handlerType"></param>
        void AddHandler(Type messageType, Type handlerType);

        /// <summary>
        /// 移除处理器
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="handlerType"></param>
        void RemoveHandler(Type messageType, Type handlerType);
    }
}
