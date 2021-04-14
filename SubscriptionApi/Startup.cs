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

namespace SubscriptionApi
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
            //services.AddControllers();
            #region eventbusʹ�÷�ʽһ
            //services.AddEventBus(options => options.AutoRegistrarHandlersAssemblies = new[] { typeof(Startup).Assembly })
            //    .AddRabbitMq(options =>
            //    {
            //        //������Ϣ��Ӧ��Exchange��Queue���������ã���ʹ��Ĭ�ϵģ�
            //        options.AddSubscribeConfigures(configureOptions =>
            //        {
            //            configureOptions.Add(new RabbitMqSubscribeConfigure(typeof(CustomerEvent),RabbitMqConst.DefaultExchangeName,RabbitMqConst.DefaultQueueName));
            //        });
            //    });
            //services.Configure<RabbitMqOptions>(Configuration.GetSection("RabbitMq"));
            //services.AddRabbitMq();
            #endregion

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
