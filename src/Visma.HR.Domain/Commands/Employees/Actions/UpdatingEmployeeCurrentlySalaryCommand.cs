namespace Visma.HR.Domain.Commands.Employees.Actions
{
    public class UpdatingEmployeeCurrentlySalaryCommand : EmployeeCommand
    {
        public UpdatingEmployeeCurrentlySalaryCommand(Guid id,
                                                      decimal currentySalary)
        {
            Id = id;
            CurrentlySalary = currentySalary;
        }
    }
}
