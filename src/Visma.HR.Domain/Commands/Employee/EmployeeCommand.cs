using Visma.HR.Domain.Core.Commands;

namespace Visma.HR.Domain.Commands.Employee
{
    public abstract class EmployeeCommand : Command
    {
        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public DateTime EmploymentDate { get; protected set; }

        public bool Boss { get; protected set; }

        public decimal CurrentlySalary { get; protected set; }

        public string Role { get; protected set; }

        public string PostalCode { get; protected set; }

        public string Number { get; protected set; }

        public string Street { get; protected set; }

        public string City { get; protected set; }

        public string State { get; protected set; }

        public string Country { get; protected set; }
    }
}
