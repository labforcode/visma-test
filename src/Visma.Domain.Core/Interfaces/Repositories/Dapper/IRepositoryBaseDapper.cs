namespace Visma.Domain.Core.Interfaces.Repositories.Dapper
{
    public interface IRepositoryBaseDapper<T> where T : class
    {
        void Dispose();
    }
}
