using Microsoft.Extensions.DependencyInjection;
using Visma.Domain.Core.Interfaces.UoW;
using Visma.Infra.Data.UoW;

namespace Visma.Infra.CrossCutting.IoC
{
    public static class UoWDI
    {
        public static void RegisterUoW(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
