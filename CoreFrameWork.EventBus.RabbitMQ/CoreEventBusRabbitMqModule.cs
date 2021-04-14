using CoreFrameWork.Modularity;
using CoreFrameWork.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.RabbitMQ
{
    /// <summary>
    /// 核心事件总线RabbitMq模块
    /// </summary>
    [DependsOn(
        typeof(CoreEventBusModule),
        typeof(CoreRabbitMqModule))]
    public  class CoreEventBusRabbitMqModule: CoreModuleBase
    {
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Items.TryGetValue(nameof(EventBusBuilder), out var eventBusBuilder);
            ((EventBusBuilder)eventBusBuilder).AddRabbitMq();
        }

    }
}
