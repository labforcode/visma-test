using Visma.Core.Infra.CrossCutting.IoC;
using Visma.HR.Infra.CrossCutting.IoC;

namespace Visma.HR.Api.Extensions
{
    ///<inheritdoc/>
    public static class DependenceInjection
    {
        ///<inheritdoc/>
        public static void AddNativeDependenceInjection(this IServiceCollection services, IConfiguration configuration)
        {
            BootstraperCoreDI.Injector(services);
            BootstraperHRDI.Injector(services, configuration);
        }
    }
}
