using CoreFrameWork.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.Mysql
{
    /// <summary>
    /// 核心事件总线SqlServer模块
    /// </summary>
    [DependsOn(typeof(CoreEventBusModule))]
    public class CoreEventBusMysqlModule: CoreModuleBase
    {
        private readonly IConfiguration _configuration;
        public CoreEventBusMysqlModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.Configure<EventBusMysqlOptions>(_configuration.GetSection("EventBus:Storage"));
            context.Items.TryGetValue(nameof(EventBusBuilder), out var eventBusBuilder);
            ((EventBusBuilder)eventBusBuilder).AddMysql();
        }
    }
}
