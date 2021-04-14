using CoreFrameWork.EventBus.RabbitMQ;
using CoreFrameWork.EventBus.SqlServer;
using CoreFrameWork.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublishApi
{
    [DependsOn(
        typeof(CoreEventBusRabbitMqModule),
        typeof(CoreEventBusSqlServerModule))]
    public class StartupModule : CoreModuleBase
    {
        public IConfiguration Configuration { get; }

        public StartupModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddControllers();

            context.Services.Configure<EventBusRabbitMqOptions>(options =>
            {
                //配置Exchange（可选）
                options.AddPublishConfigure(configureOptions =>
                {
                    configureOptions.ExchangeName = RabbitMqConst.DefaultExchangeName;
                });
            });

            context.Services.Configure<EventBusSqlServerOptions>(options =>
            {
                //配置Connection（必须）
                options.ConnectionString = Configuration.GetConnectionString("customer");
            });
        }

        public override void Configure(ApplicationBuilderContext context)
        {
            var app = context.ApplicationBuilder;
            var env = app.ApplicationServices.GetRequiredService<IHostEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
