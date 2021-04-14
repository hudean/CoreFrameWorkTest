using Microsoft.Extensions.DependencyInjection;

namespace CoreFrameWork.EventBus.Local
{
    /// <summary>
    /// 事件总线本地集合扩展
    /// </summary>
    public static class EventBusLocalCollectionExtensions
    {
        public static EventBusBuilder AddLocalMq(this EventBusBuilder builder)
        {
            builder.Service.AddSingleton<IMessagePublisher, LocalMessagePublisher>();
            builder.Service.AddSingleton<IMessageSubscribe, LocalMessageSubscribe>();
            return builder;
        }
    }
}
