using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Visma.Domain.Commands.Employee.Actions;
using Visma.Domain.Commands.Employee.Handlers;

namespace Visma.Infra.CrossCutting.IoC
{
    public static class CommandsDI
    {
        public static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddingEmployeeCommand, bool>, AddingEmployeeCommandHandler>();
            services.AddScoped<IRequestHandler<DeletingEmployeeCommand, bool>, DeletingEmployeeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatingEmployeeCommand, bool>, UpdatingEmployeeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatingEmployeeSalaryCommand, bool>, UpdatingEmployeeSalaryCommandHandler>();
        }
    }
}
