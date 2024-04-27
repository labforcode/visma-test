using Visma.HR.Domain.Core.Entities;
using Visma.HR.Domain.Entities.Employees;
using Visma.HR.Domain.Validators.Addresses.Actions;

namespace Visma.HR.Domain.Entities.Addresses
{
    public class Address : Entity
    {
        public string PostalCode { get; private set; }

        public string Number { get; private set; }

        public string Street { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public Guid EmployeeId { get; private set; }

        public virtual Employee Employee { get; private set; }

        private Address(string postalCode,
                        string number,
                        string street,
                        string city,
                        string state,
                        string country,
                        Guid employeeId)
        {

            PostalCode = postalCode;
            Number = number;
            Street = street;
            City = city;
            State = state;
            Country = country;
            EmployeeId = employeeId;

            Validate(this, new CreateAddressValidator());
        }

        protected Address() { }

        public static void Create()
        {

        }
    }
}
