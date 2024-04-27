using Microsoft.Extensions.DependencyInjection;
using Visma.HR.Application.Interfaces.Employees;
using Visma.HR.Application.Services.Employees;

namespace Visma.HR.Infra.CrossCutting.IoC
{
    public static class ApplicationDI
    {
        public static void RegisterApplications(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeAppService, EmployeeAppService>();
        }
    }
}
