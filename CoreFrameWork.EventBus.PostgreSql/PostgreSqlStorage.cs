using CoreFrameWork.EventBus.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreFrameWork.EventBus.PostgreSql
{
    public class PostgreSqlStorage : IStorage
    {
        private readonly IOptions<EventBusPostgreSqlOptions> _options;
        private readonly ILogger<PostgreSqlStorage> _logger;

        public PostgreSqlStorage(
            IOptions<EventBusPostgreSqlOptions> options,
            ILogger<PostgreSqlStorage> logger)
        {
            _options = options;
            _logger = logger;
        }

        /// <summary>
        /// 初始化消息表
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            var sql = $@"
                     CREATE TABLE IF NOT EXISTS {_options.Value.PublishMessageTableName} (
                     Id VARCHAR(200) NOT NULL,
                     Version INT NOT NULL,
                     MessageType TEXT NOT NULL,
                     MessageData TEXT NOT NULL,
                     CreateTime timestamp(6) NOT NULL,
                     UtcTime timestamp(6) NOT NULL,
                    PRIMARY KEY (Id)
                    );";

            using (var connection = new NpgsqlConnection(_options.Value.ConnectionString))
            {
                connection.ExecuteNonQuery(sql);
            }
            _logger.LogInformation($"initial message table successfully. table name is [{_options.Value.PublishMessageTableName}]");
            await Task.CompletedTask;
        }

        public void StoreMessage(MediumMessage message, object dbTransaction = null)
        {
            throw new NotImplementedException();
        }
    }
}
