namespace Visma.HR.Domain.Commands.Employees.Actions
{
    public class UpdatingEmployeeSalaryCommand : EmployeeCommand
    {
        public UpdatingEmployeeSalaryCommand(Guid id,
                                             decimal currentySalary)
        {
            Id = id;
            CurrentlySalary = currentySalary;
        }
    }
}
