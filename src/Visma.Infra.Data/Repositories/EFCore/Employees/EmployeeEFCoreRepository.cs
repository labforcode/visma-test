using Visma.Domain.Entities.Employees;
using Visma.Domain.Interfaces.Repositories.EFCore.Employees;
using Visma.Infra.Data.Contexts;

namespace Visma.Infra.Data.Repositories.EFCore.Employees
{
    public class EmployeeEFCoreRepository : RepositoryBase<Employee>, IEmployeeEFCoreRepository
    {
        public EmployeeEFCoreRepository(CoreContext context) : base(context) { }
    }
}
