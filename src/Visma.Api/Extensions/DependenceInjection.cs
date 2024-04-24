using Visma.Infra.CrossCutting.IoC;

namespace Visma.Api.Extensions
{
    ///<inheritdoc/>
    public static class DependenceInjection
    {
        ///<inheritdoc/>
        public static void AddNativeDependenceInjection(this IServiceCollection services, IConfiguration configuration)
        {
            BootstraperDI.Injector(services, configuration);
        }
    }
}
