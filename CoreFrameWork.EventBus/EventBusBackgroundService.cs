using CoreFrameWork.EventBus.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 事件总线后台服务
    /// </summary>
    public class EventBusBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public EventBusBackgroundService(
            IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var provider = _serviceScopeFactory.CreateScope().ServiceProvider;
            var options = provider.GetRequiredService<IOptions<EventBusOptions>>();

            //初始化订阅
            var messageSubscribe = provider.GetService<IMessageSubscribe>();
            messageSubscribe?.Initialize(options.Value.AutoRegistrarHandlersAssemblies);

            //初始化消息存储
            var storage = provider.GetService<IStorage>();
            storage?.InitializeAsync(stoppingToken);

            return Task.CompletedTask;
        }
    }
}
