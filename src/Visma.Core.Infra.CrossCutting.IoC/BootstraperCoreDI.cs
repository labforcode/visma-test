using Microsoft.Extensions.DependencyInjection;
using Visma.Core.Infra.CrossCutting.Security.Interfaces;
using Visma.Core.Infra.CrossCutting.Security.Services;

namespace Visma.Core.Infra.CrossCutting.IoC
{
    public class BootstraperCoreDI
    {
        public static void Injector(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
