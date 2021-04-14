using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Modularity
{
    /// <summary>
    /// 应用建设者上下文
    /// </summary>
    public class ApplicationBuilderContext
    {
        /// <summary>
        /// 应用建设者
        /// </summary>
        public IApplicationBuilder ApplicationBuilder { get; }

        public ApplicationBuilderContext(IApplicationBuilder applicationBuilder)
        {
            ApplicationBuilder = applicationBuilder ?? throw new ArgumentNullException(nameof(applicationBuilder));
        }
    }
}
