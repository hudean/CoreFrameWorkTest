using CoreFrameWork.EventBus.Storage;
using CoreFrameWork.EventBus.Transaction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.PostgreSql
{
    /// <summary>
    /// PostgreSql服务集合扩展
    /// </summary>
    public static class PostgreSqlServiceCollectionExtensions
    {
        public static EventBusBuilder AddSqlServer(this EventBusBuilder builder,
           Action<EventBusPostgreSqlOptions> options = null)
        {
            builder.Service.TryAddSingleton<IStorage, PostgreSqlStorage>();
            builder.Service.TryAddTransient<ITransaction, PostgreSqlTransaction>();
            if (options != null)
                builder.Service.Configure(options);
            return builder;
        }

    }
   
}
