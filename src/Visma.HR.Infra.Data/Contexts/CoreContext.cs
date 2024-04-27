using Microsoft.EntityFrameworkCore;
using Visma.HR.Domain.Entities.Employees;
using Visma.HR.Infra.Data.Mappings.Employees;

namespace Visma.HR.Infra.Data.Contexts
{
    public class CoreContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.HasDefaultSchema("public");
            builder.ApplyConfiguration(new EmployeeMap());
        }
    }
}
