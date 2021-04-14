using CoreFrameWork.EventBus.Storage;
using CoreFrameWork.EventBus.Transaction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.SqlServer
{

    /// <summary>
    /// SqlServer服务集合扩展
    /// </summary>
    public static class SqlServerServiceCollectionExtensions
    {
        public static EventBusBuilder AddSqlServer(this EventBusBuilder builder,
            Action<EventBusSqlServerOptions> options = null)
        {
            builder.Service.TryAddSingleton<IStorage, SqlServerStorage>();
            builder.Service.TryAddTransient<ITransaction, SqlServerTransaction>();
            if (options != null)
                builder.Service.Configure(options);
            return builder;
        }
    }
}
