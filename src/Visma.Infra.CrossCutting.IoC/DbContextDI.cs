using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Visma.Infra.CrossCutting.Common.Settings;
using Visma.Infra.Data.Contexts;

namespace Visma.Infra.CrossCutting.IoC
{
    /// <inheritdoc/>
    public static class DbContextDI
    {
        /// <inheritdoc/>
        public static void RegisterContext(IServiceCollection services)
        {
            services.AddDbContext<CoreContext>(opt => opt.UseNpgsql(AppSettingsDto.Settings.ConnectionStrings.VismaDb));
            services.AddScoped<CoreContext>();
        }
    }
}
