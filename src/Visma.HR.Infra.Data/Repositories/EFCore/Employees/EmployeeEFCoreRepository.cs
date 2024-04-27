using Visma.HR.Domain.Entities.Employees;
using Visma.HR.Domain.Interfaces.Repositories.EFCore.Employees;
using Visma.HR.Infra.Data.Contexts;

namespace Visma.HR.Infra.Data.Repositories.EFCore.Employees
{
    public class EmployeeEFCoreRepository : RepositoryBase<Employee>, IEmployeeEFCoreRepository
    {
        public EmployeeEFCoreRepository(CoreContext context) : base(context) { }
    }
}
