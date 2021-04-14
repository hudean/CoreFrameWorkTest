using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreFrameWork.EventBus.Transaction
{
    /// <summary>
    /// 事务接口
    /// </summary>
    public interface ITransaction
    {
        bool AutoCommit { get; set; }

        void Commit();

        Task CommitAsync(CancellationToken cancellationToken = default);

        void Rollback();

        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
