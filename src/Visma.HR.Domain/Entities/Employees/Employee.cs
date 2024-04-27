using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Core.Entities;
using Visma.HR.Domain.Entities.Addresses;
using Visma.HR.Domain.Validators.Employees.Actions;

namespace Visma.HR.Domain.Entities.Employees
{
    public class Employee : Entity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public DateTime EmploymentDate { get; private set; }

        public decimal CurrentlySalary { get; private set; }

        public string Role { get; private set; }

        public Guid BossId { get; private set; }

        public virtual Address HomeAddress { get; private set; }

        private Employee(string firstName,
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
            BossId = CreateBossId(bossId);
            HomeAddress = Address.Create(postalCode, number, street, city, state, country, Id);

            Validate(this, new CreateEmployeeValidator());
        }

        protected Employee() { }

        public static Employee Create(AddingEmployeeCommand command)
        {
            return new Employee(command.FirstName,
                                command.LastName,
                                command.BirthDate,
                                command.EmploymentDate,
                                command.CurrentlySalary,
                                command.Role,
                                command.BossId,
                                command.PostalCode,
                                command.Number,
                                command.Street,
                                command.City,
                                command.State,
                                command.Country);
        }

        private Guid CreateBossId(string bossId) => string.IsNullOrEmpty(bossId) ? Guid.Empty : Guid.Parse(bossId);
    }
}
