﻿using Visma.HR.Domain.Entities.Employees;

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
        /// <param name="bossId"></param>
        /// <param name="pageSize"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GettingEmployeesAsync(string name, DateTime startBirthDate, DateTime endBirthDate, string bossId, int pageSize, int index);

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
    }
}
