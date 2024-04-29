using Bogus;
using Visma.Core.Infra.CrossCutting.Common.Constants;
using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Entities.Employees;

namespace Visma.HR.Domain.Tests.Employees
{
    public abstract class EmployeeFixture
    {
        protected Guid Id = default;
        protected string FirstName = default;
        protected string LastName = default;
        protected DateTime BirthDate = default;
        protected DateTime EmploymentDate = default;
        protected decimal CurrentlySalary = default;
        protected string Role = default;
        protected string HomeAddress = default;
        protected string BossId = default;

        protected void GenerateProperties(string role = "")
        {

            Id = GenerateId();
            FirstName = GenerateFirstName();
            LastName = GenerateLastName();
            BirthDate = GenerateBirthDate();
            EmploymentDate = GenerateEmploymentDate();
            CurrentlySalary = GenerateCurrentlySalary();
            Role = string.IsNullOrEmpty(role) ? EmployeeRole.SoftwareEngineer : role;
            HomeAddress = GenerateFakeEmployeeAddress();
            BossId = GenerateBossId();
        }

        protected Employee GenerateEmployee(string role = "",
                                            DateTime birthDate = default,
                                            DateTime employmentDate = default,
                                            decimal currentlySalary = 0)
        {
            GenerateProperties(role);
            if (Role == EmployeeRole.ChiefExecutiveOfficer) BossId = Guid.Empty.ToString();

            if (birthDate != DateTime.MinValue) BirthDate = birthDate;

            if (employmentDate != DateTime.MinValue) EmploymentDate = employmentDate;

            if (currentlySalary != 0) CurrentlySalary = currentlySalary;

            var createCommand = GenerateFakeAddingEmployeeCommand();
            var employee = Employee.Create(createCommand);

            return employee;
        }

        protected AddingEmployeeCommand GenerateFakeAddingEmployeeCommand()
        {
            return new AddingEmployeeCommand(FirstName,
                                             LastName,
                                             BirthDate,
                                             EmploymentDate,
                                             CurrentlySalary,
                                             Role,
                                             HomeAddress,
                                             BossId);
        }



        protected UpdatingEmployeeCommand GenerateFakeUpdatingEmployeeCommand(Guid id)
        {

            return new UpdatingEmployeeCommand(id,
                                               FirstName,
                                               LastName,
                                               BirthDate,
                                               EmploymentDate,
                                               Role,
                                               HomeAddress,
                                               BossId);
        }


        protected UpdatingEmployeeCurrentlySalaryCommand GenerateFakeUpdatingEmployeeCurrentlySalaryCommand(Guid id,
                                                                                                            decimal currentlySalary)
        {
            CurrentlySalary = currentlySalary;
            return new UpdatingEmployeeCurrentlySalaryCommand(id,
                                                              CurrentlySalary);
        }


        protected static Guid GenerateId() => Guid.NewGuid();

        protected string GenerateFirstName() => new Faker().Person.FirstName;

        protected string GenerateLastName() => new Faker().Person.LastName;

        protected DateTime GenerateBirthDate(int minAge = 18, int maxAge = 70) => new Faker().Date.Between(new DateTime(DateTime.Now.Year - maxAge, 1, 1), new DateTime(DateTime.Now.Year - minAge, 1, 1)).Date;

        protected DateTime GenerateEmploymentDate() => new Faker().Date.Between(new DateTime(2000, 1, 1), DateTime.Now.Date).Date;

        protected decimal GenerateCurrentlySalary() => new Faker().Random.Decimal(1000, 100000);

        protected string GenerateBossId() => Guid.NewGuid().ToString();

        protected string GenerateFakeEmployeeAddress()
        {
            var faker = new Faker();
            var street = faker.Address.StreetAddress();
            var aparmentNumber = faker.Random.Int(1, 1000);
            var city = faker.Address.City();
            var state = faker.Address.State();
            var zipCode = faker.Address.ZipCode();

            return $"{street}, Apartment #{aparmentNumber}, {city}, {state} {zipCode} USA";
        }
    }
}
