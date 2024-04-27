namespace Visma.HR.Application.DTOs.Employees
{
    public class UpdatingEmployeeDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime EmploymentDate { get; set; }

        public string Role { get; set; }

        public Guid BossId { get; set; }

        public string PostalCode { get; set; }

        public string Number { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
