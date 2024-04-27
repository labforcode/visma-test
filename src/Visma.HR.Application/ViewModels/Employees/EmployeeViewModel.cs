using System.Text.Json.Serialization;
using Visma.HR.Domain.Entities.Employees;

namespace Visma.HR.Application.ViewModels.Employees
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate { get; set; }

        public string EmploymentDate { get; set; }

        public decimal CurrentlySalary { get; set; }

        public string Role { get; set; }

        public string HomeAddress { get; set; }

        public Guid BossId { get; set; }

        [JsonIgnore]
        public int TotalRecords { get; set; }

        public static EmployeeViewModel Parse(Employee employee)
        {
            return new EmployeeViewModel
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = $"{employee.BirthDate:yyyy-MM-dd}",
                EmploymentDate = $"{employee.EmploymentDate:yyyy-MM-dd}",
                CurrentlySalary = employee.CurrentlySalary,
                Role = employee.Role,
                HomeAddress = employee.HomeAddress,
                BossId = employee.BossId,
                TotalRecords = employee.TotalRecords
            };
        }
    }
}
