using Visma.Domain.Core.Entities;
using Visma.Domain.Validators.Employees.Actions;
using Visma.Domain.ValueObjects.Addresses;

namespace Visma.Domain.Entities.Employees
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime EmploymentDate { get; set; }

        public bool Boss { get; set; }

        public Address HomeAddress { get; set; }

        public decimal CurrentlySalary { get; set; }

        public string Role { get; set; }

        private Employee(string firstName,
                         string lastName,
                         DateTime birthDate,
                         DateTime employmentDate,
                         bool boss,
                         Address homeAddress,
                         decimal currentlySalary,
                         string role)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            EmploymentDate = employmentDate;
            Boss = boss;
            HomeAddress = homeAddress;
            CurrentlySalary = currentlySalary;
            Role = role;

            Validate(this, new CreateEmployeeValidator());
        }

        protected Employee() { }

        public static void Create()
        {

        }
    }
}
