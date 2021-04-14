using CoreFrameWork.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 核心事件总线模块
    /// </summary>
    public class CoreEventBusModule : CoreModuleBase
    {
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            var eventBusBuilder = context.Services.AddEventBus();
            context.Items.Add(nameof(EventBusBuilder), eventBusBuilder);
        }
    }
}
