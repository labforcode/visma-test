using Visma.HR.Application.DTOs.Employees;
using Visma.HR.Application.Interfaces.Employees;
using Visma.HR.Domain.Core.Interfaces.Bus;

namespace Visma.HR.Application.Services.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IMediatorHandler _bus;

        public EmployeeAppService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task AddingEmployeeAsync(AddingEmployeeDto dto)
        {
            var command = AddingEmployeeDto.Parse(dto);
            await _bus.SendCommandAsync(command);
        }

        public Task UpdatingEmployeeAsync(UpdatingEmployeeDto dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdatingEmployeeSalaryAsync(UpdatingEmployeeSalaryDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeletingEmployeeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task GettingEmployeeAsync(Guid id)
        {
            throw new NotImplementedException();
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
