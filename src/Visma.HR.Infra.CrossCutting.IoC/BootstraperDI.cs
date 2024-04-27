using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Visma.HR.Domain.Core.Interfaces.Bus;
using Visma.HR.Domain.Core.Notifications;
using Visma.HR.Infra.CrossCutting.Bus;
using Visma.HR.Infra.CrossCutting.Common.Settings;

namespace Visma.HR.Infra.CrossCutting.IoC
{
    public class BootstraperDI
    {
        public static void Injector(IServiceCollection services, IConfiguration configuration)
        {
            AppSettingsDto.ParseAppSettings(configuration);
            services.AddSingleton<AppSettingsDto>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<NotificationContext>();
            services.AddTransient<IMediatorHandler, InMemoryBus>();
            services.RegisterContext();
            services.RegisterApplications();
            services.RegisterUoW();
            services.RegisterCommands();
            services.RegisterRepositories();


            //TO DO
            //services.AddScoped<ITokenService, TokenService>();
        }
    }
}
