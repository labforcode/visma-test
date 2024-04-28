using Dapper;
using Visma.HR.Domain.Entities.Employees;
using Visma.HR.Domain.Interfaces.Repositories.Dapper.Employees;
using Visma.HR.Infra.CrossCutting.Common.Lists;

namespace Visma.HR.Infra.Data.Repositories.Dapper.Employees
{
    public class EmployeeDapperRepository : RepositoryBaseDapper, IEmployeeDapperRepository
    {
        public async Task<Employee> GettingEmployee(Guid id)
        {
            try
            {
                var conn = Connection;
                var query = $@"SELECT e.id                 AS Id,
                                      e.first_name         AS FirstName,
                                      e.last_name          AS LastName,
                                      e.birth_date         AS BirthDate,
                                      e.employment_date    AS EmploymentDate,
                                      e.currently_salary   AS CurrentlySalary,
                                      e.role               AS Role,
                                      e.home_address       AS HomeAddress, 
                                      e.boss_id            AS BossId
           						FROM employees AS e 
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

        public async Task<IEnumerable<Employee>> GettingEmployeesAsync(string name, DateTime startBirthDate, DateTime endBirthDate, string bossId, int pageSize, int index)
        {
            try
            {
                var conn = Connection;
                var filters = new DynamicParameters();
                var query = ApplyFilters(filters, name, startBirthDate, endBirthDate, bossId, pageSize, index);

                return await conn.QueryAsync<Employee>(query, filters);
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

        public async Task<bool> CheckCEOWasRegistered(Guid id = default)
        {
            try
            {
                var conn = Connection;
                var query = $@"SELECT COUNT(*)
							   FROM employees AS e	
							   WHERE e.role = @role ";

                var filters = new DynamicParameters();
                filters.Add("@role", EmployeeRole.ChiefExecutiveOfficer);
                if(id != Guid.Empty)
                {
                    query = $@"{query}
                                AND e.id <> @employee_id;";
                    filters.Add("@employee_id", id);
                }

                return await conn.QueryFirstOrDefaultAsync<bool>(query, filters);
            }
            catch
            {
                throw;
            }
        }

        private string ApplyFilters(DynamicParameters filters, string name, DateTime startBirthDate, DateTime endBirthDate, string bossId, int pageSize, int index)
        {
            var query = $@"SELECT e.id                 AS Id,
                                  e.first_name         AS FirstName,
                                  e.last_name          AS LastName,
                                  e.birth_date         AS BirthDate,
                                  e.employment_date    AS EmploymentDate,
                                  e.currently_salary   AS CurrentlySalary,
                                  e.role               AS Role,
                                  e.home_address       AS HomeAddress, 
                                  e.boss_id            AS BossId,
                                  COUNT(*) OVER()      AS TotalRecords   
           					FROM employees AS e
                            WHERE 1 = 1 ";

            query = ApllyFilterName(filters, query, name);
            query = ApllyFilterBirthDateInterval(filters, query, startBirthDate, endBirthDate);
            query = ApllyFilterBossId(filters, query, bossId);

            if (pageSize > 0) query = Paginate(query, index, pageSize);

            return query;
        }

        private string ApllyFilterName(DynamicParameters filters, string query, string name)
        {
            if (string.IsNullOrEmpty(name)) return query;

            query = $@"{query}
                        AND CONCAT(e.first_name, ' ', e.last_name) LIKE @name ";

            filters.Add("@name", $"%{name}%");
            return query;
        }

        private string ApllyFilterBirthDateInterval(DynamicParameters filters, string query, DateTime startBirthDate, DateTime endBirthDate)
        {
            if (startBirthDate == DateTime.MinValue || endBirthDate == DateTime.MinValue) return query;

            query = $@"{query}
                        AND birth_date >= @start_birth_date
                        AND birth_date <= @end_birth_date";

            filters.Add("@start_birth_date", startBirthDate);
            filters.Add("@end_birth_date", endBirthDate);
            return query;
        }

        private string ApllyFilterBossId(DynamicParameters filters, string query, string bossId)
        {
            if (string.IsNullOrEmpty(bossId) || Guid.Parse(bossId) == Guid.Empty) return query;

            query = $@"{query}
                        AND e.boss_id = @boss_id ";

            filters.Add("@boss_id", Guid.Parse(bossId));
            return query;
        }
    }
}
