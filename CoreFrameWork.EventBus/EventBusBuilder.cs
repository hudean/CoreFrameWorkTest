using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 事件总线构建器
    /// </summary>
    public class EventBusBuilder
    {
        public EventBusBuilder(IServiceCollection service)
        {
            Service = service;
        }
        public IServiceCollection Service { get; set; }
    }
}
