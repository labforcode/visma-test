namespace Visma.HR.Application.DTOs.Employees
{
    public class UpdatingEmployeeSalaryDto
    {
        public Guid Id { get; set; }

        public decimal CurrentlySalary { get; set; }
    }
}
