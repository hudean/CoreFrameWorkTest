using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity.Abstraction
{
    /// <summary>
    /// 核心模块描述接口
    /// </summary>
    public interface ICoreModuleDescriptor
    {
        /// <summary>
        /// 模块类型
        /// </summary>
        Type ModuleType { get; }

        /// <summary>
        /// 模块接口
        /// </summary>
        ICoreModule Instance { get; }

        /// <summary>
        /// 只读的模块描述
        /// </summary>
        IReadOnlyList<ICoreModuleDescriptor> Dependencies { get; }
    }
}
