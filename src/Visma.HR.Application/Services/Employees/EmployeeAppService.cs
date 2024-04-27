using Visma.HR.Application.DTOs.Employees;
using Visma.HR.Application.Interfaces.Employees;
using Visma.HR.Application.ViewModels.Employees;
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

        public Task GettingEmployeesAsync(int pageSize, int index, string name, DateTime startBirthDate, DateTime endBirthDate, string bossId)
        {
            throw new NotImplementedException();
        }

        public Task GettingInfoRoleAsync(string role)
        {
            throw new NotImplementedException();
        }
    }
}
