using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.Local
{
    public class LocalMessageSubscribe : MessageSubscribeBase
    {
        private readonly IMessageHandlerManager _messageHandlerManager;

        public LocalMessageSubscribe(IMessageHandlerManager messageHandlerManager)
        {
            _messageHandlerManager = messageHandlerManager;
        }

        protected override void Subscribe(Type messageType, Type handlerType)
        {
            _messageHandlerManager.AddHandler(messageType, handlerType);
        }

        public override void Subscribe<T, TH>()
        {
            Subscribe(typeof(T), typeof(TH));
        }

        public override void UnSubscribe<T, TH>()
        {
            _messageHandlerManager.RemoveHandler(typeof(T), typeof(TH));
        }
    }
}
