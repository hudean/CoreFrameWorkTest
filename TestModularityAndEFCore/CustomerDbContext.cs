using CoreFrameWork.EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestModularityAndEFCore.Entities;

namespace TestModularityAndEFCore
{
    public class CustomerDbContext : CoreDbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        { 
        }

        public DbSet<Student> Students { get; set; }
    }
}
