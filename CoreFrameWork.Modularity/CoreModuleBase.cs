using CoreFrameWork.Modularity.Abstraction;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CoreFrameWork.Modularity
{
    /// <summary>
    /// 基础核心模块
    /// </summary>
    public class CoreModuleBase : ICoreModule
    {
        public virtual void Configure(ApplicationBuilderContext app)
        {
           
        }

        public virtual void ConfigureServices(ServiceCollectionContext context)
        {
            
        }

        public virtual void PostConfigure(ApplicationBuilderContext context)
        {
            
        }

        public virtual void PostConfigureServices(ServiceCollectionContext context)
        {
           
        }

        public virtual void PreConfigure(ApplicationBuilderContext context)
        {
            
        }

        public virtual void PreConfigureServices(ServiceCollectionContext context)
        {
           
        }

        public virtual void Shutdown(ShutdownApplicationContext context)
        {
            
        }
        public static bool IsCoreModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(ICoreModule).GetTypeInfo().IsAssignableFrom(type);
        }

        public static void CheckCoreModuleType(Type moduleType)
        {
            if (!IsCoreModule(moduleType))
            {
                throw new ArgumentException("Given type is not an Core module: " + moduleType.AssemblyQualifiedName);
            }
        }
    }
}
