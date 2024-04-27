using Npgsql;
using System.Data;
using Visma.HR.Domain.Core.Interfaces.Repositories.Dapper;
using Visma.HR.Infra.CrossCutting.Common.Settings;

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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
