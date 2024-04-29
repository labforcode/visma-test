using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Visma.Core.Infra.CrossCutting.Common.Sections;
using Visma.Core.Infra.CrossCutting.Logging.Contexts;
using Visma.Core.Infra.CrossCutting.Security.Interfaces;
using Visma.Core.Infra.CrossCutting.Security.Services;

namespace Visma.Core.Infra.CrossCutting.IoC
{
    public class BootstraperCoreDI
    {
        public static void Injector(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<LogContext>(opt => opt.UseNpgsql(AppSettingsDto.Settings.ConnectionStrings.LogDb));
            services.AddScoped<LogContext>();

            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
