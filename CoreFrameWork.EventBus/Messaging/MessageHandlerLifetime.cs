using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息处理器生命周期
    /// </summary>
    public enum MessageHandlerLifetime
    {
        /// <summary>
        /// 短暂/瞬态
        /// </summary>
        Transient,

        /// <summary>
        /// 单例
        /// </summary>
        Singleton
    }
}
