using CoreFrameWork.EventBus.Transaction;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreFrameWork.EventBus.SqlServer
{

    /// <summary>
    /// SqlServer事务
    /// </summary>
    public class SqlServerTransaction : TransactionBase
    {
        public SqlServerTransaction(IMessagePublisher publisher)
        : base(publisher)
        {
        }

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

        public override async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            switch (DbTransaction)
            {
                case IDbTransaction dbTransaction:
                    dbTransaction.Rollback();
                    break;
                case IDbContextTransaction dbContextTransaction:
                    await dbContextTransaction.RollbackAsync(cancellationToken);
                    break;
            }
        }

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
