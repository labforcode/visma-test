namespace Visma.Domain.Core.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
