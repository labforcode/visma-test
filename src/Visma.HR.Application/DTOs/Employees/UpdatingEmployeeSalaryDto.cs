using Visma.HR.Domain.Commands.Employees.Actions;

namespace Visma.HR.Application.DTOs.Employees
{
    public class UpdatingEmployeeSalaryDto
    {
        public Guid Id { get; set; }

        public decimal CurrentlySalary { get; set; }

        public static UpdatingEmployeeCurrentlySalaryCommand Parse(UpdatingEmployeeSalaryDto dto) => new UpdatingEmployeeCurrentlySalaryCommand(dto.Id,
                                                                                                                              dto.CurrentlySalary);
    }
}
