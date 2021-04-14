using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity.Abstraction
{
    /// <summary>
    /// 模块加载器接口
    /// </summary>
    public interface IModuleLoader
    {
        ICoreModuleDescriptor[] LoadModules(IServiceCollection services,Type startupModuleType);
    }
}
