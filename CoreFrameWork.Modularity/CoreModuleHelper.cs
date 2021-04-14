using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CoreFrameWork.Modularity
{
    /// <summary>
    /// 核心模块帮助类
    /// </summary>
    public class CoreModuleHelper
    {
        /// <summary>
        /// 发现所有模块类型
        /// </summary>
        /// <param name="startupModuleType"></param>
        /// <returns></returns>
        public static List<Type> FindAllModuleTypes(Type startupModuleType)
        {
            var moduleTypes = new List<Type>();
            AddModules(moduleTypes, startupModuleType);
            return moduleTypes;
        }

        /// <summary>
        /// 查找依赖模块类型
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            CoreModuleBase.CheckCoreModuleType(moduleType);
            var source = new List<Type>();
            foreach (var dependedTypes in moduleType.GetCustomAttributes().OfType<DependsOnAttribute>())
            {
                foreach (var dependedType in dependedTypes.GetDependedTypes())
                {
                    if (!source.Contains(dependedType))
                        source.Add(dependedType);
                }
            }
            return source;
        }

        private static void AddModules(List<Type> moduleTypes, Type moduleType)
        {
            CoreModuleBase.CheckCoreModuleType(moduleType);
            if (moduleTypes.Contains(moduleType))
                return;
            moduleTypes.Add(moduleType);
            foreach (var dependedModuleType in FindDependedModuleTypes(moduleType))
                AddModules(moduleTypes, dependedModuleType);
        }
    }
}
