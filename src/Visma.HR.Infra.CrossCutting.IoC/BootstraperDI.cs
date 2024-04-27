using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Visma.HR.Domain.Core.Notifications;
using Visma.HR.Infra.CrossCutting.Common.Settings;

namespace Visma.HR.Infra.CrossCutting.IoC
{
    public class BootstraperDI
    {
        public static void Injector(IServiceCollection services, IConfiguration configuration)
        {
            AppSettingsDto.ParseAppSettings(configuration);
            services.AddSingleton<AppSettingsDto>();

            services.AddScoped<NotificationContext>();
            //services.AddScoped<ITokenService, TokenService>();

            services.RegisterContext();
            services.RegisterUoW();
            services.RegisterCommands();
            services.RegisterRepositories();

            //QueriesDI.RegisterQueries(services);
        }
    }
}
