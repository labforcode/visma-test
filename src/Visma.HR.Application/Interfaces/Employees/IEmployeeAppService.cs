using Visma.HR.Application.DTOs.Employees;

namespace Visma.HR.Application.Interfaces.Employees
{
    public interface IEmployeeAppService
    {
        /// <summary>
        /// Adding new employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddingEmployeeAsync(AddingEmployeeDto dto);

        /// <summary>
        /// Updating employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdatingEmployeeAsync(UpdatingEmployeeDto dto);

        /// <summary>
        /// Updating just employee salary
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdatingEmployeeSalaryAsync(UpdatingEmployeeSalaryDto dto);

        /// <summary>
        /// Deleting employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletingEmployeeAsync(Guid id);

        /// <summary>
        /// Getting a particular employee by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task GettingEmployeeAsync(Guid id);

        /// <summary>
        /// Getting employee by filter
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="index"></param>
        /// <param name="name"></param>
        /// <param name="startBirthDate"></param>
        /// <param name="endBirthDate"></param>
        /// <param name="bossId"></param>
        /// <returns></returns>
        Task GettingEmployeesAsync(int pageSize, int index, string name, DateTime startBirthDate, DateTime endBirthDate, string bossId);

        /// <summary>
        /// Getting employee count and average salary for particular Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task GettingInfoRoleAsync(string role);
    }
}
