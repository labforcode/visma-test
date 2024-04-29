namespace Visma.HR.Domain.Commands.Employees.Actions
{
    public class DeletingEmployeeCommand : EmployeeCommand
    {
        public DeletingEmployeeCommand(Guid id)
        {
            Id = id;
        }
    }
}
