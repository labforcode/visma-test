using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Visma.Infra.CrossCutting.Common.Settings;
using Visma.Infra.Data.Contexts;

namespace Visma.Infra.CrossCutting.IoC
{
    public static class DbContextDI
    {
        public static void RegisterContext(this IServiceCollection services)
        {
            services.AddDbContext<CoreContext>(opt => opt.UseNpgsql(AppSettingsDto.Settings.ConnectionStrings.VismaDb));
            services.AddScoped<CoreContext>();
        }
    }
}
