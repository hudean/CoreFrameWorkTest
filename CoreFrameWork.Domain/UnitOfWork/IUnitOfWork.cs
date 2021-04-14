using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreFrameWork.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
