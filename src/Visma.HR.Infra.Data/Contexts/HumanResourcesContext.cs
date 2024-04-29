using Microsoft.EntityFrameworkCore;
using Visma.HR.Domain.Entities.Employees;
using Visma.HR.Infra.Data.Mappings.Employees;

namespace Visma.HR.Infra.Data.Contexts
{
    public class HumanResourcesContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public HumanResourcesContext(DbContextOptions<HumanResourcesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("public");
            builder.ApplyConfiguration(new EmployeeMap());
        }
    }
}
