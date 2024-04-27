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
                                     string bossId,
                                     string postalCode,
                                     string number,
                                     string street,
                                     string city,
                                     string state,
                                     string country)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            EmploymentDate = employmentDate;
            CurrentlySalary = currentlySalary;
            Role = role;
            BossId = bossId;
            PostalCode = postalCode;
            Number = number;
            Street = street;
            City = city;
            State = state;
            Country = country;
        }
    }
}
