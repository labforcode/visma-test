using Visma.HR.Application.DTOs.Employees;
using Visma.HR.Application.Interfaces.Employees;
using Visma.HR.Application.ViewModels.Employees;
using Visma.HR.Application.ViewModels.Roles;
using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Core.Interfaces.Bus;
using Visma.HR.Domain.Interfaces.Repositories.Dapper.Employees;

namespace Visma.HR.Application.Services.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IEmployeeDapperRepository _employeeDapperRepository;

        public EmployeeAppService(IMediatorHandler bus,
                                  IEmployeeDapperRepository employeeDapperRepository)
        {
            _bus = bus;
            _employeeDapperRepository = employeeDapperRepository;
        }

        public async Task AddingEmployeeAsync(AddingEmployeeDto dto)
        {
            var command = AddingEmployeeDto.Parse(dto);
            await _bus.SendCommandAsync(command);
        }

        public async Task UpdatingEmployeeAsync(UpdatingEmployeeDto dto)
        {
            var command = UpdatingEmployeeDto.Parse(dto);
            await _bus.SendCommandAsync(command);
        }

        public async Task UpdatingEmployeeSalaryAsync(UpdatingEmployeeSalaryDto dto)
        {
            var command = UpdatingEmployeeSalaryDto.Parse(dto);
            await _bus.SendCommandAsync(command);
        }

        public async Task DeletingEmployeeAsync(Guid id)
        {
            var command = new DeletingEmployeeCommand(id);
            await _bus.SendCommandAsync(command);
        }

        public async Task<EmployeeViewModel> GettingEmployeeAsync(Guid id)
        {
            var employee = await _employeeDapperRepository.GettingEmployee(id);
            if (employee is null) return new EmployeeViewModel();

            return EmployeeViewModel.Parse(employee);
        }

        public async Task<IEnumerable<EmployeeViewModel>> GettingEmployeesAsync(string name, DateTime startBirthDate, DateTime endBirthDate, string role, string bossId, int pageSize, int index)
        {
            var employees = await _employeeDapperRepository.GettingEmployeesAsync(name, startBirthDate, endBirthDate, role, bossId, pageSize, index);
            if (employees is null) return Enumerable.Empty<EmployeeViewModel>();

            return employees.Select(employee => EmployeeViewModel.Parse(employee));
        }

        public async Task<InfoRoleViewModel> GettingInfoRoleAsync(string role)
        {
            var infoRole = new InfoRoleViewModel();
            var employees = await _employeeDapperRepository.GettingEmployeesAsync(role: role);
            if (employees is null || employees.Any() is false) return infoRole;

            infoRole.Role = role;
            infoRole.EmployeeCount = employees.Count();
            infoRole.AverageSalary = employees.Sum(employee => employee.CurrentlySalary) / employees.Count();

            return infoRole;
        }
    }
}
