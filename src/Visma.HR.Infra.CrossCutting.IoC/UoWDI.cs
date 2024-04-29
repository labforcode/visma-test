using Microsoft.Extensions.DependencyInjection;
using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Infra.Data.UoW;

namespace Visma.HR.Infra.CrossCutting.IoC
{
    public static class UoWDI
    {
        public static void RegisterUoW(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
