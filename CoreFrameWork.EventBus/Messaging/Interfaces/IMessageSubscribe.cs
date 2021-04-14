using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息订阅接口
    /// </summary>
    public interface IMessageSubscribe
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="assemblies"></param>
        void Initialize(params Assembly[] assemblies);

        /// <summary>
        /// 订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void Subscribe<T, TH>()
            where T : class, IMessage
            where TH : IMessageHandler<T>, new();

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void UnSubscribe<T, TH>()
            where T : class, IMessage
            where TH : IMessageHandler<T>, new();
    }
}
