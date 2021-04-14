using CoreFrameWork.Modularity.Abstraction;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity
{
    /// <summary>
    /// 核心模块应用建设者扩展
    /// </summary>
    public static class CoreFrameworkApplicationBuilderExtensions
    {
        public static void BuildApplicationBuilder(this IApplicationBuilder app)
        {
            var application = app.ApplicationServices.GetRequiredService<ICoreApplicationManager>();
            application.Configure(app);

            var requiredService = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            requiredService.ApplicationStopping.Register(() => application.Shutdown(app.ApplicationServices));
        }
    }
}
