using CoreFrameWork.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFrameWork.RabbitMQ
{
    public class CoreRabbitMqModule : CoreModuleBase
    {
        public IConfiguration Configuration { get; }

        public CoreRabbitMqModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.Configure<RabbitMqOptions>(Configuration.GetSection("RabbitMq"));
            context.Services.AddRabbitMq();
        }
    }
}
