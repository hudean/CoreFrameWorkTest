using CoreFrameWork.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.PostgreSql
{
    [DependsOn(typeof(CoreEventBusModule))]
    public class CoreEventBusPostgreSqlModule : CoreModuleBase
    {
        private readonly IConfiguration _configuration;

        public CoreEventBusPostgreSqlModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.Configure<EventBusPostgreSqlOptions>(_configuration.GetSection("EventBus:Storage"));
            context.Items.TryGetValue(nameof(EventBusBuilder), out var eventBusBuilder);
            ((EventBusBuilder)eventBusBuilder).AddSqlServer();
        }
    }
}
