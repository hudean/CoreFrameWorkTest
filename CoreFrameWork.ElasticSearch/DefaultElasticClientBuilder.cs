using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.ElasticSearch
{
    /// <summary>
    /// 默认ElasticClient构造器
    /// </summary>
    public class DefaultElasticClientBuilder
    {
        public DefaultElasticClientBuilder(IServiceCollection services, string name)
        {
            Services = services;
            Name = name;
        }

        public string Name { get; }

        public IServiceCollection Services { get; }
    }
}
