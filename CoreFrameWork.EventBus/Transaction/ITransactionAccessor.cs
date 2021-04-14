using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EventBus.Transaction
{
    /// <summary>
    /// 事务访问器接口
    /// </summary>
    public interface ITransactionAccessor
    {
        ITransaction Transaction { get; set; }
    }
}
