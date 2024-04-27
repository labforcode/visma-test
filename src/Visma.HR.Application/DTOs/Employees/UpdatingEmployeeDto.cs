using Visma.HR.Domain.Commands.Employees.Actions;

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

        public string HomeAddress { get; set; }

        public string BossId { get; set; }

        public static UpdatingEmployeeCommand Parse(UpdatingEmployeeDto dto) => new UpdatingEmployeeCommand(dto.Id,
                                                                                                            dto.FirstName,
                                                                                                            dto.LastName,
                                                                                                            dto.BirthDate,
                                                                                                            dto.EmploymentDate,
                                                                                                            dto.Role,
                                                                                                            dto.HomeAddress,
                                                                                                            dto.BossId);
    }
}
