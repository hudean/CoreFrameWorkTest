using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息发布接口
    /// </summary>
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(T message) where T : class, IMessage;
    }
}
