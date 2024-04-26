using Npgsql;
using System.Data;
using Visma.Domain.Core.Interfaces.Repositories.Dapper;
using Visma.Infra.CrossCutting.Common.Settings;

namespace Visma.Infra.Data.Repositories.Dapper
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
