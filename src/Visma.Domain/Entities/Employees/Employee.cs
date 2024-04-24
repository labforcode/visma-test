using Visma.Domain.Core.Entities;
using Visma.Domain.Entities.Addresses;
using Visma.Domain.Validators.Employees.Actions;

namespace Visma.Domain.Entities.Employees
{
    public class Employee : Entity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public DateTime EmploymentDate { get; private set; }

        public bool Boss { get; private set; }

        public decimal CurrentlySalary { get; private set; }

        public string Role { get; private set; }

        public virtual Address HomeAddress { get; private set; }

        private Employee(string firstName,
                         string lastName,
                         DateTime birthDate,
                         DateTime employmentDate,
                         bool boss,
                         decimal currentlySalary,
                         string role,
                         Address homeAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            EmploymentDate = employmentDate;
            Boss = boss;
            CurrentlySalary = currentlySalary;
            Role = role;
            HomeAddress = homeAddress;

            //TO DO como chamar para criar o endereço

            //Validar o endereço
            Validate(this, new CreateEmployeeValidator());
        }

        protected Employee() { }

        public static void Create()
        {

        }
    }
}
