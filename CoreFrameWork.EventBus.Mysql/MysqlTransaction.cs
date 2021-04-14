using CoreFrameWork.EventBus.Transaction;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreFrameWork.EventBus.Mysql
{
    public class MysqlTransaction : TransactionBase
    {
        public MysqlTransaction(IMessagePublisher publisher)
        : base(publisher)
        {
        }

        /// <summary>
        /// 提交
        /// </summary>
        public override void Commit()
        {
            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Commit();
                    break;
                case IDbContextTransaction dbContextTransaction:
                    dbContextTransaction.Commit();
                    break;
            }
            Flush();
        }

        /// <summary>
        /// 异步提交
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Commit();
                    break;
                case IDbContextTransaction dbContextTransaction:
                    await dbContextTransaction.CommitAsync(cancellationToken);
                    break;
            }
            Flush();
        }

      
        /// <summary>
        /// 回滚
        /// </summary>
        public override void Rollback()
        {
            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Rollback();
                    break;
                case IDbContextTransaction dbContextTransaction:
                    dbContextTransaction.Rollback();
                    break;
            }
        }

        /// <summary>
        /// 回滚异步方法
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Rollback();
                    break;
                case IDbContextTransaction dbContextTransaction:
                  await  dbContextTransaction.RollbackAsync();
                    break;
            }
        }


        /// <summary>
        /// 释放
        /// </summary>
        public override void Dispose()
        {
            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Dispose();
                    break;
                case IDbContextTransaction dbContextTransaction:
                    dbContextTransaction.Dispose();
                    break;
            }
        }
    }
}
