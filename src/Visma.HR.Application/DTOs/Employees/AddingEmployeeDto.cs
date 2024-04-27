using Visma.HR.Domain.Commands.Employees.Actions;

namespace Visma.HR.Application.DTOs.Employees
{
    public class AddingEmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime EmploymentDate { get; set; }

        public decimal CurrentlySalary { get; set; }

        public string Role { get; set; }

        public string BossId { get; set; }

        public string PostalCode { get; set; }

        public string Number { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public static AddingEmployeeCommand Parse(AddingEmployeeDto dto) => new AddingEmployeeCommand(dto.FirstName,
                                                                                                      dto.LastName,
                                                                                                      dto.BirthDate,
                                                                                                      dto.EmploymentDate,
                                                                                                      dto.CurrentlySalary,
                                                                                                      dto.Role,
                                                                                                      dto.BossId,
                                                                                                      dto.PostalCode,
                                                                                                      dto.Number,
                                                                                                      dto.Street,
                                                                                                      dto.City,
                                                                                                      dto.State,
                                                                                                      dto.Country);
    }
}
