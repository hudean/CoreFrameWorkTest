using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CoreFrameWork.ElasticSearch.Options
{
    /// <summary>
    /// Elastic客户端工厂选项
    /// </summary>
    public class ElasticClientFactoryOptions
    {
        private readonly TimeSpan _minimumElasticClientLifeTime = TimeSpan.FromHours(1.0);
        private TimeSpan _elasticClientLifeTime = TimeSpan.FromHours(24.0);

        public TimeSpan ElasticClientLifeTime
        {
            get => _elasticClientLifeTime;
            set
            {
                if (value != Timeout.InfiniteTimeSpan && value < _minimumElasticClientLifeTime)
                    throw new ArgumentException(nameof(value));
                _elasticClientLifeTime = value;
            }
        }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string[] Urls { get; set; }

        public string DefaultIndex { get; set; } = "elastic_search_default_index";

    }
}
