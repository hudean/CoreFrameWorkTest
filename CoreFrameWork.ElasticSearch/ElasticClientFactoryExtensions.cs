using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.ElasticSearch
{
    /// <summary>
    /// Elastic客户端工厂扩展
    /// </summary>
    public static class ElasticClientFactoryExtensions
    {
        public static ElasticClient CreateClient(this IElasticClientFactory elasticClientFactory)
        {
            return elasticClientFactory.CreateClient(Microsoft.Extensions.Options.Options.DefaultName);
        }
    }
}
