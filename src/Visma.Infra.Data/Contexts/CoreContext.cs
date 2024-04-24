using Microsoft.EntityFrameworkCore;
using Visma.Domain.Entities.Addresses;
using Visma.Domain.Entities.Employees;
using Visma.Infra.Data.Mappings.Addresses;
using Visma.Infra.Data.Mappings.Employees;

namespace Visma.Infra.Data.Contexts
{
    public class CoreContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.HasDefaultSchema("public");
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new AddressMap());
        }
    }
}
