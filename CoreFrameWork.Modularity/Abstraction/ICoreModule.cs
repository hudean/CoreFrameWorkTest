using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity.Abstraction
{
    /// <summary>
    /// 核心模块接口
    /// </summary>
    public interface ICoreModule
    {
        /// <summary>
        /// 预配置服务
        /// </summary>
        /// <param name="context"></param>
        void PreConfigureServices(ServiceCollectionContext context);

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="context"></param>
        void ConfigureServices(ServiceCollectionContext context);

        /// <summary>
        /// 配置后服务
        /// </summary>
        /// <param name="context"></param>
        void PostConfigureServices(ServiceCollectionContext context);

        /// <summary>
        /// 预配置
        /// </summary>
        /// <param name="context"></param>
        void PreConfigure(ApplicationBuilderContext context);

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="app"></param>
        void Configure(ApplicationBuilderContext app);

        /// <summary>
        /// 后配置
        /// </summary>
        /// <param name="context"></param>
        void PostConfigure(ApplicationBuilderContext context);

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="context"></param>
        void Shutdown(ShutdownApplicationContext context);
    }
}
