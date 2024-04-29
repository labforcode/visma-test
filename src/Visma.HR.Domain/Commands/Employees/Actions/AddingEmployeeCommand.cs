namespace Visma.HR.Domain.Commands.Employees.Actions
{
    public class AddingEmployeeCommand : EmployeeCommand
    {
        public AddingEmployeeCommand(string firstName,
                                     string lastName,
                                     DateTime birthDate,
                                     DateTime employmentDate,
                                     decimal currentlySalary,
                                     string role,
                                     string homeAddress,
                                     string bossId)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            EmploymentDate = employmentDate;
            CurrentlySalary = currentlySalary;
            Role = role;
            HomeAddress = homeAddress;
            BossId = bossId;
        }
    }
}
