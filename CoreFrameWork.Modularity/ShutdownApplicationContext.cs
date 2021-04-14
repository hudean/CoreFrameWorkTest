using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity
{
    /// <summary>
    /// 关闭应用上下文
    /// </summary>
    public class ShutdownApplicationContext
    {
        public IServiceProvider ServiceProvider { get; }

        public ShutdownApplicationContext(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
    }
}
