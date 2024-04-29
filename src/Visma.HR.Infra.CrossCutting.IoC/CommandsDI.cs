using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Commands.Employees.Handlers;

namespace Visma.HR.Infra.CrossCutting.IoC
{
    public static class CommandsDI
    {
        public static void RegisterCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddingEmployeeCommand, bool>, AddingEmployeeCommandHandler>();
            services.AddScoped<IRequestHandler<DeletingEmployeeCommand, bool>, DeletingEmployeeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatingEmployeeCommand, bool>, UpdatingEmployeeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatingEmployeeCurrentlySalaryCommand, bool>, UpdatingEmployeeCurrentlySalaryCommandHandler>();
        }
    }
}
