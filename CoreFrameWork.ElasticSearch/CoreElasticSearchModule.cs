using CoreFrameWork.ElasticSearch.Options;
using CoreFrameWork.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFrameWork.ElasticSearch
{
    /// <summary>
    /// 核心ElasticSearch模块
    /// </summary>
    public class CoreElasticSearchModule : CoreModuleBase
    {
        public IConfiguration Configuration { get; }

        public CoreElasticSearchModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.Configure<ElasticClientFactoryOptions>(Configuration.GetSection("ElasticSearch"));
            context.Services.AddElasticClientFactory();
        }
    }
}
