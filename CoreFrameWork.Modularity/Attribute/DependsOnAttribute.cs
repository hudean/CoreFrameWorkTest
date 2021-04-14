using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity
{
    /// <summary>
    /// 依赖特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute: Attribute
    {
        /// <summary>
        /// 依赖类型
        /// </summary>
        public Type[] DependedTypes { get; }

        public DependsOnAttribute(params Type[] dependedTypes)
        {
            DependedTypes = dependedTypes ?? new Type[0];
        }

        /// <summary>
        /// 获取依赖类型
        /// </summary>
        /// <returns></returns>
        public virtual Type[] GetDependedTypes()
        {
            return DependedTypes;
        }
    }
}
