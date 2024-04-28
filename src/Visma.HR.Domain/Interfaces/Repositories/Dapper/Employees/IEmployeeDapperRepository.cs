using Visma.HR.Domain.Entities.Employees;

namespace Visma.HR.Domain.Interfaces.Repositories.Dapper.Employees
{
    public interface IEmployeeDapperRepository
    {
        /// <summary>
        /// Get employee by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee> GettingEmployee(Guid id);

        /// <summary>
        /// Getting employee by filter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startBirthDate"></param>
        /// <param name="endBirthDate"></param>
        /// <param name="role"></param>
        /// <param name="bossId"></param>
        /// <param name="pageSize"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GettingEmployeesAsync(string name = "", DateTime startBirthDate = default, DateTime endBirthDate = default, string role = "", string bossId = "", int pageSize = 0, int index = 0);

        /// <summary>
        /// Check if emplyee was registered by id
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        Task<bool> CheckEmployeeWasRegistered(Guid id);

        /// <summary>
        /// Check if emplyee was registered by first and last name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        Task<bool> CheckEmployeeWasRegistered(string firstName, string lastName);

        /// <summary>
        /// Check if CEO was registered
        /// </summary>
        /// <returns></returns>
        Task<bool> CheckCEOWasRegistered(Guid id = default);
    }
}
