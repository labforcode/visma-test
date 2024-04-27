using Visma.HR.Domain.Core.Commands;

namespace Visma.HR.Domain.Commands.Employees
{
    public abstract class EmployeeCommand : Command
    {
        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public DateTime EmploymentDate { get; protected set; }

        public decimal CurrentlySalary { get; protected set; }

        public string Role { get; protected set; }

        public string HomeAddress { get; protected set; }

        public string BossId { get; protected set; }
    }
}
