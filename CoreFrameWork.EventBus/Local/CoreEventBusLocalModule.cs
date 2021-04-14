using CoreFrameWork.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.Local
{
    /// <summary>
    /// 核心事件总线本地模块
    /// </summary>
    [DependsOn(typeof(CoreEventBusModule))]
    public class CoreEventBusLocalModule: CoreModuleBase
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="context"></param>
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Items.TryGetValue(nameof(EventBusBuilder), out var eventBusBuilder);
            ((EventBusBuilder)eventBusBuilder).AddLocalMq();
        }
    }
}
