using Visma.HR.Domain.Commands.Employees.Actions;

namespace Visma.HR.Application.DTOs.Employees
{
    public class UpdatingEmployeeSalaryDto
    {
        public Guid Id { get; set; }

        public decimal CurrentlySalary { get; set; }

        public static UpdatingEmployeeSalaryCommand Parse(UpdatingEmployeeSalaryDto dto) => new UpdatingEmployeeSalaryCommand(dto.Id,
                                                                                                                              dto.CurrentlySalary);
    }
}
