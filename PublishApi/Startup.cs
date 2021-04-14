using CoreFrameWork.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublishApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers();
            #region eventbusʹ�÷�ʽһ
            //services.AddEventBus()
            //    .AddRabbitMq(options =>
            //    {
            //        //������Ϣ��Ӧ��Exchange���������ã���ʹ��Ĭ�ϵģ�
            //        options.AddPublishConfigure(configureOptions =>
            //        {
            //            configureOptions.ExchangeName = RabbitMqConst.DefaultExchangeName;
            //        });
            //    })
            //    .AddSqlServer(options =>
            //    {
            //        options.ConnectionString = Configuration.GetConnectionString("customer");
            //    });
            //services.Configure<RabbitMqOptions>(Configuration.GetSection("RabbitMq"));
            //services.AddRabbitMq();
            #endregion

            //ʹ��ģ��
            services.ConfigureServiceCollection<StartupModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.BuildApplicationBuilder();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
