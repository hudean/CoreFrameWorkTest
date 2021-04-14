using CoreFrameWork.EntityFrameWorkCore;
using CoreFrameWork.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestModularityAndEFCore
{
    [DependsOn(typeof(CoreEfCoreModule)
       /* typeof(CoreEventBusSqlServerModule)*/)]
    public class StartupModule: CoreEfCoreModule
    {
        public  IConfiguration Configuration;


        public StartupModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddControllers();
            context.Services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("customer"));
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
