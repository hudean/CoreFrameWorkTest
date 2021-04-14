using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CoreFrameWork.EventBus.Transaction
{
    /// <summary>
    /// 事务访问器
    /// </summary>
    public class TransactionAccessor : ITransactionAccessor
    {
        private readonly AsyncLocal<ITransaction> _transaction = new AsyncLocal<ITransaction>();

        public ITransaction Transaction
        {
            get => _transaction.Value;
            set
            {
                if (value != null)
                {
                    _transaction.Value = value;
                }
            }
        }
    }
}
