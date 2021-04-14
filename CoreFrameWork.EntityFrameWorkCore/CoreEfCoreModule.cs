using CoreFrameWork.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EntityFrameWorkCore
{
    public class CoreEfCoreModule : CoreModuleBase
    {
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddEntityFrameworkRepository();
        }
    }
}
