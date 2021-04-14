using CoreFrameWork.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Redis
{
    /// <summary>
    /// 核心Redis模块
    /// </summary>
    public class CoreRedisModule : CoreModuleBase
    {
        private readonly IConfiguration _configuration;

        public CoreRedisModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services
                .AddRedisCache()
                .Configure<RedisCacheOptions>(_configuration.GetSection("Redis"));
        }
    }
}
