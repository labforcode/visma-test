using Bogus;
using Visma.Api.Tests.Base.Fixtures;
using Visma.HR.Application.DTOs.Employees;

namespace Visma.Api.Tests.Employees
{
    public class EmployeeApiFixture : BaseApiFixture
    {
        private List<string> _roles = new List<string>
        {
            "Chief executive officer",
            "Chief marketing officer",
            "Chief operations officer",
            "Chief information officer",
            "Human resources manager",
            "Information technology manager:",
            "Marketing manager",
            "Product manager:",
            "Sales manager",
            "Administrative assistant",
            "Bookkeeper",
            "Business analyst",
            "Sales representative",
            "Software engineer",
        };

        protected AddingEmployeeDto GenerateFakeEmployee()
        {
            var homeAddress = GenerateFakeEmployeeAddress();
            return new Faker<AddingEmployeeDto>("en_US")
                .CustomInstantiator(fake => new AddingEmployeeDto
                {
                    FirstName = fake.Person.FirstName,
                    LastName = fake.Person.LastName,
                    BirthDate = fake.Person.DateOfBirth.Date,
                    EmploymentDate = fake.Date.Between(new DateTime(2000, 1, 1), DateTime.Now.Date).Date,
                    CurrentlySalary = fake.Random.Decimal(1000, 100000),
                    Role = _roles[fake.Random.Int(0, 13)],
                    HomeAddress = homeAddress
                });
        }

        private string GenerateFakeEmployeeAddress()
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
