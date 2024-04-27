namespace Visma.HR.Domain.Commands.Employees.Actions
{
    public class UpdatingEmployeeCommand : EmployeeCommand
    {
        public UpdatingEmployeeCommand(Guid id,
                                       string firstName,
                                       string lastName,
                                       DateTime birthDate,
                                       DateTime employmentDate,
                                       string role,
                                       string homeAddress,
                                       string bossId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            EmploymentDate = employmentDate;
            Role = role;
            HomeAddress = homeAddress;
            BossId = bossId;
        }
    }
}
