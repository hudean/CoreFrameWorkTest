using CoreFrameWork.EventBus.Storage;
using CoreFrameWork.EventBus.Transaction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.Mysql
{
    public static  class MysqlServiceCollectionExtensions
    {
        public static EventBusBuilder AddMysql(this EventBusBuilder builder, Action<EventBusMysqlOptions> options = null)
        {
            builder.Service.TryAddSingleton<IStorage, MysqlStorage>();
            builder.Service.TryAddTransient<ITransaction, MysqlTransaction>();
            if (options != null)
                builder.Service.Configure(options);
            return builder;
        }
    }
}
