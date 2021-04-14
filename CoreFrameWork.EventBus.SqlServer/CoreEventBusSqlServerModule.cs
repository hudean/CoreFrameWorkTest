using CoreFrameWork.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFrameWork.EventBus.SqlServer
{
    /// <summary>
    /// 核心事件总线SqlServer模块
    /// </summary>
    [DependsOn(typeof(CoreEventBusModule))]
    public class CoreEventBusSqlServerModule : CoreModuleBase
    {
        private readonly IConfiguration _configuration;

        public CoreEventBusSqlServerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.Configure<EventBusSqlServerOptions>(_configuration.GetSection("EventBus:Storage"));
            context.Items.TryGetValue(nameof(EventBusBuilder), out var eventBusBuilder);
            ((EventBusBuilder)eventBusBuilder).AddSqlServer();
        }
    }
}
