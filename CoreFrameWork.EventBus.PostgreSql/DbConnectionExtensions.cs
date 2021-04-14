using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CoreFrameWork.EventBus.PostgreSql
{
    /// <summary>
    /// DbConnection扩展方法
    /// </summary>
    public static class DbConnectionExtensions
    {
        public static int ExecuteNonQuery(this IDbConnection connection, string sql, IDbTransaction transaction = null,
          params object[] sqlParams)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            foreach (var param in sqlParams)
            {
                command.Parameters.Add(param);
            }

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            return command.ExecuteNonQuery();
        }
    }
}
