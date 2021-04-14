using CoreFrameWork.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreFrameWork.EntityFrameWorkCore.UnitOfWork
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        public List<DbContext> DbContexts { get; }

        public EfCoreUnitOfWork()
        {
            DbContexts = new List<DbContext>(); ;
        }

        public void Commit()
        {
            DbContexts.ForEach(dbContext => dbContext.SaveChanges());
        }

        public Task CommitAsync()
        {
            var tasks = new List<Task<int>>();
            DbContexts.ForEach(dbContext => tasks.Add(dbContext.SaveChangesAsync()));
            return Task.WhenAll(tasks);
        }

        public void RegisterCoreDbContext(DbContext coreDbContext)
        {
            if (!DbContexts.Exists(dbCtx => dbCtx.Equals(coreDbContext)))
            {
                DbContexts.Add(coreDbContext);
            }
        }
    }
}
