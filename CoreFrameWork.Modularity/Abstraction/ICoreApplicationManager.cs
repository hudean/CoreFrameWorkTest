using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity.Abstraction
{
    /// <summary>
    /// 核心应用管理接口
    /// </summary>
    public interface ICoreApplicationManager
    {
        /// <summary>
        /// 配置配置服务
        /// </summary>
        /// <param name="services"></param>
        void ConfigureConfigureServices(IServiceCollection services);
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="app"></param>
        void Configure(IApplicationBuilder app);

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="serviceProvider"></param>
        void Shutdown(IServiceProvider serviceProvider);
    }
}
