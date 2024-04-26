namespace Visma.Domain.Core.Interfaces.Repositories.Common
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Dispose();
    }
}
