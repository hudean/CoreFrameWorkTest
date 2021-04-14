using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.ElasticSearch
{
    /// <summary>
    /// Elastic客户端工厂接口
    /// </summary>
    public interface IElasticClientFactory
    {
        ElasticClient CreateClient(string name);
    }
}
