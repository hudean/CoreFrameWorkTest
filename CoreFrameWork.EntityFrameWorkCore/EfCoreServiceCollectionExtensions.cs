using CoreFrameWork.Domain.Repositories;
using CoreFrameWork.Domain.UnitOfWork;
using CoreFrameWork.EntityFrameWorkCore.Repositories;
using CoreFrameWork.EntityFrameWorkCore.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.EntityFrameWorkCore
{
    public static class EfCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkRepository(this IServiceCollection services)
        {
            services.TryAddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.TryAddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.TryAddScoped(typeof(IUnitOfWork), typeof(EfCoreUnitOfWork));
            return services;
        }
    }
}
