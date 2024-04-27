using Dapper;
using Visma.HR.Domain.Entities.Employees;
using Visma.HR.Domain.Interfaces.Repositories.Dapper.Employees;

namespace Visma.HR.Infra.Data.Repositories.Dapper.Employees
{
    public class EmployeeDapperRepository : RepositoryBaseDapper, IEmployeeDapperRepository
    {
        private const string Query = $@"SELECT e.id                 AS Id,
                                               e.first_name         AS FirstName,
                                               e.last_name          AS LastName,
                                               e.birth_date         AS BirthDate,
                                               e.employment_date    AS EmploymentDate,
                                               e.currently_salary   AS CurrentlySalary,
                                               e.role               AS Role,
                                               e.home_address       AS HomeAddress, 
                                               e.boss_id            AS BossId
           							    FROM employees AS e ";


        public async Task<Employee> GettingEmployee(Guid id)
        {
            try
            {
                var conn = Connection;
                var query = $@"{Query} 
							    WHERE e.id = @employee_id;";

                var filters = new DynamicParameters();
                filters.Add("@employee_id", id);

                return await conn.QueryFirstOrDefaultAsync<Employee>(query, filters);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CheckEmployeeWasRegistered(Guid id)
        {
            try
            {
                var conn = Connection;
                var query = $@"SELECT COUNT(*)
							   FROM employees AS e	
							   WHERE e.id = @employee_id;";

                var filters = new DynamicParameters();
                filters.Add("@employee_id", id);

                return await conn.QueryFirstOrDefaultAsync<bool>(query, filters);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CheckEmployeeWasRegistered(string firstName, string lastName)
        {
            try
            {
                var conn = Connection;
                var query = $@"SELECT COUNT(*)
							   FROM employees AS e	
							   WHERE e.first_name = @first_name
								AND e.last_name = @last_name;";

                var filters = new DynamicParameters();
                filters.Add("@first_name", firstName);
                filters.Add("@last_name", lastName);

                return await conn.QueryFirstOrDefaultAsync<bool>(query, filters);
            }
            catch
            {
                throw;
            }
        }
    }
}
