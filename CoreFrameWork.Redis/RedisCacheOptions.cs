using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Redis
{
    /// <summary>
    /// Redis缓存选项
    /// </summary>
    public class RedisCacheOptions
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// 连接健康检查
        /// 默认60秒检测一次
        /// </summary>
        public int ConnectionHealthCheck { get; set; } = 60;
    }
}
