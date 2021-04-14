using CoreFrameWork.Modularity.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity
{
    /// <summary>
    /// 核心框架服务集合扩展
    /// </summary>
    public static class CoreFrameworkServiceCollectionExtensions
    {
        public static void ConfigureServiceCollection<T>(this IServiceCollection service) where T : ICoreModule
        {
            ConfigureServiceCollection(service, typeof(T));
        }

        public static void ConfigureServiceCollection(this IServiceCollection service, Type startupModuleType)
        {
            CoreApplicationManagerFactory.CreateCoreApplication(startupModuleType, service);
        }
    }
}
