using CoreFrameWork.Modularity.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity
{
    /// <summary>
    /// 核心应用管理工厂
    /// </summary>
    public static class CoreApplicationManagerFactory
    {
        public static ICoreApplicationManager CreateCoreApplication( Type startupModuleType,IServiceCollection services)
        {
            return new CoreApplicationManager(startupModuleType, services);
        }
    }
}
