using Microsoft.Extensions.DependencyInjection;
using Visma.Domain.Core.Interfaces.Repositories.Common;
using Visma.Domain.Core.Interfaces.Repositories.Dapper;
using Visma.Domain.Interfaces.Repositories.Dapper.Employees;
using Visma.Infra.Data.Repositories.Dapper;
using Visma.Infra.Data.Repositories.Dapper.Employees;
using Visma.Infra.Data.Repositories.EFCore;

namespace Visma.Infra.CrossCutting.IoC
{
    public static class RepositoriesDI
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            //EF Core
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            //Dapper
            services.AddScoped<IRepositoryBaseDapper, RepositoryBaseDapper>();
            services.AddScoped<IEmployeeDapperRepository, EmployeeDapperRepository>();
        }
    }
}
