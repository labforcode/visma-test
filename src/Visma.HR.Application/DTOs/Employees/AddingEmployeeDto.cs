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

        public string HomeAddress { get; set; }

        public static AddingEmployeeCommand Parse(AddingEmployeeDto dto) => new AddingEmployeeCommand(dto.FirstName,
                                                                                                      dto.LastName,
                                                                                                      dto.BirthDate,
                                                                                                      dto.EmploymentDate,
                                                                                                      dto.CurrentlySalary,
                                                                                                      dto.Role,
                                                                                                      dto.HomeAddress);
    }
}
