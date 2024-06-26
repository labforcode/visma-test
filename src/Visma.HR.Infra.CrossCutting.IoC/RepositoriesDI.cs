﻿using Microsoft.Extensions.DependencyInjection;
using Visma.HR.Domain.Core.Interfaces.Repositories.Common;
using Visma.HR.Domain.Core.Interfaces.Repositories.Dapper;
using Visma.HR.Domain.Interfaces.Repositories.Dapper.Employees;
using Visma.HR.Domain.Interfaces.Repositories.EFCore.Employees;
using Visma.HR.Infra.Data.Repositories.Dapper;
using Visma.HR.Infra.Data.Repositories.Dapper.Employees;
using Visma.HR.Infra.Data.Repositories.EFCore;
using Visma.HR.Infra.Data.Repositories.EFCore.Employees;

namespace Visma.HR.Infra.CrossCutting.IoC
{
    public static class RepositoriesDI
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            //EF Core
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IEmployeeEFCoreRepository, EmployeeEFCoreRepository>();

            //Dapper
            services.AddScoped<IRepositoryBaseDapper, RepositoryBaseDapper>();
            services.AddScoped<IEmployeeDapperRepository, EmployeeDapperRepository>();
        }
    }
}
