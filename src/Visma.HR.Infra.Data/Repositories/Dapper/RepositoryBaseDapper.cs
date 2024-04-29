using Npgsql;
using System.Data;
using Visma.Core.Infra.CrossCutting.Common.Sections;
using Visma.HR.Domain.Core.Interfaces.Repositories.Dapper;

namespace Visma.HR.Infra.Data.Repositories.Dapper
{
    public class RepositoryBaseDapper : IRepositoryBaseDapper
    {
        private readonly string _connectionString;

        public IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public RepositoryBaseDapper()
        {
            _connectionString = AppSettingsDto.Settings.ConnectionStrings.VismaDb;
        }

        protected static string Order(string query, string column, string direction)
        {
            if (string.IsNullOrEmpty(column)) return query;

            return $@"{query} ORDER BY {column} {direction} ";
        }

        protected static string Paginate(string query, int offset, int limit)
        {

            offset = limit * (offset - 1);
            return $@"{query} OFFSET {offset} LIMIT {limit} ";
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
