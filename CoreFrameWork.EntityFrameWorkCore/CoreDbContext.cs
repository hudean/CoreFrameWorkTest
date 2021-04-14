using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EntityFrameWorkCore
{
    public class CoreDbContext : DbContext
    {

        public CoreDbContext(DbContextOptions options)
           : base(options)
        {
            //var serviceProvider = options.FindExtension<CoreOptionsExtension>().ApplicationServiceProvider;
            //MessagePublisher = serviceProvider.GetService<IMessagePublisher>();
        }
    }
}
