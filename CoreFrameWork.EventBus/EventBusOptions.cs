using System.Reflection;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 事件总线选项
    /// </summary>
    public class EventBusOptions
    {
        public Assembly[] AutoRegistrarHandlersAssemblies { get; set; }
    }
}
