using Visma.Infra.CrossCutting.IoC;

namespace Visma.Api.Extensions
{
    ///<inheritdoc/>
    public static class DependenceInjection
    {
        /// <summary>
        /// Método de Extensão de IServiceCollection para adicionar o container de injeção de dependência nativo
        /// </summary>
        public static void AddNativeDependenceInjection(this IServiceCollection services, IConfiguration configuration)
        {
            BootstraperDI.Injector(services, configuration);
        }
    }
}
