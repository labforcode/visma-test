using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Infra.Data.Contexts;

namespace Visma.HR.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HumanResourcesContext _context;

        public UnitOfWork(HumanResourcesContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
