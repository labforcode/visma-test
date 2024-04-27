using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Visma.HR.Infra.CrossCutting.Common.Settings;
using Visma.HR.Infra.Data.Contexts;

namespace Visma.HR.Infra.CrossCutting.IoC
{
    public static class DbContextDI
    {
        public static void RegisterContext(this IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<CoreContext>(opt => opt.UseNpgsql(AppSettingsDto.Settings.ConnectionStrings.VismaDb));
            services.AddScoped<CoreContext>();
        }
    }
}
