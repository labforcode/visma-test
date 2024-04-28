using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Core.Entities;
using Visma.HR.Domain.Validators.Employees.Actions;
using Visma.HR.Infra.CrossCutting.Common.Lists;

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

        public string HomeAddress { get; private set; }

        public Guid BossId { get; private set; }

        private Employee(string firstName,
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
            BossId = CreateBossId(bossId);

            //TO DO
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
                                command.HomeAddress,
                                command.BossId);
        }

        public void Update(UpdatingEmployeeCommand command)
        {
            FirstName = command.FirstName;
            LastName = command.LastName;
            BirthDate = command.BirthDate;
            EmploymentDate = command.EmploymentDate;
            Role = command.Role;
            HomeAddress = command.HomeAddress;
            BossId = UpdateBossId(command.BossId);

            //TO DO
            Validate(this, new UpdateEmployeeValidator());
        }

        public bool CheckIfIsCEO() => Role == EmployeeRole.ChiefExecutiveOfficer;

        public bool CheckIfAgeIsAllowed()
        {
            var minAge = 18;
            var maxAge = 70;
            var age = DateTime.Now.Year - BirthDate.Year;

            return (age >= minAge) && (age <= maxAge);
        }

        public bool CheckMinEmploymentDateAllowed()
        {
            var minDate = new DateTime(2000, 1, 1).Date;

            return EmploymentDate >= minDate;
        }

        public bool CheckMaxEmploymentDateAllowed()
        {
            var maxDate = DateTime.Now.Date;

            return EmploymentDate <= maxDate;
        }

        public bool CheckMinCurrentSalaryAllowed() => CurrentlySalary >= 0;

        public void UpdateSalary(UpdatingEmployeeSalaryCommand command)
        {
            CurrentlySalary = command.CurrentlySalary;

            //TO DO
            Validate(this, new UpdateEmployeeSalaryValidator());
        }

        private Guid CreateBossId(string bossId) => string.IsNullOrEmpty(bossId) ? Guid.Empty : Guid.Parse(bossId);

        private Guid UpdateBossId(string bossId) => string.IsNullOrEmpty(bossId) ? BossId : Guid.Parse(bossId);
    }
}
