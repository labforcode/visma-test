using Visma.HR.Domain.Entities.Employees;

namespace Visma.HR.Application.ViewModels.Employees
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime EmploymentDate { get; set; }

        public decimal CurrentlySalary { get; set; }

        public string Role { get; set; }

        public string HomeAddress { get; set; }

        public Guid BossId { get; set; }

        public static EmployeeViewModel Parse(Employee employee)
        {
            return new EmployeeViewModel
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                EmploymentDate = employee.EmploymentDate,
                CurrentlySalary = employee.CurrentlySalary,
                Role = employee.Role,
                HomeAddress = employee.HomeAddress,
                BossId = employee.BossId,
            };
        }
    }
}
