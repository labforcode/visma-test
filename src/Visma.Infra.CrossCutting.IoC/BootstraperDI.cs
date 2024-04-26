using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Visma.Infra.CrossCutting.Common.Settings;

namespace Visma.Infra.CrossCutting.IoC
{
    public class BootstraperDI
    {
        public static void Injector(IServiceCollection services, IConfiguration configuration)
        {
            AppSettingsDto.ParseAppSettings(configuration);
            services.AddSingleton<AppSettingsDto>();

            //services.AddScoped<NotificationContext>();
            //services.AddScoped<ITokenService, TokenService>();

            DbContextDI.RegisterContext(services);

            //UoWDI.RegisterUoW(services);

            //DomainServicesDI.RegisterDomainServices(services);

            //CommandsDI.RegisterCommands(services);

            //RepositoriesDI.RegisterRepositories(services);

            //QueriesDI.RegisterQueries(services);
        }
    }
}
