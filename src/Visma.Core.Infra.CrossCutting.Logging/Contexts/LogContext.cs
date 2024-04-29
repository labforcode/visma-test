using Microsoft.EntityFrameworkCore;
using Visma.Core.Infra.CrossCutting.Common.Sections;
using Visma.Core.Infra.CrossCutting.Logging.Maps;
using Visma.Core.Infra.CrossCutting.Logging.Models;

namespace Visma.Core.Infra.CrossCutting.Logging.Contexts
{
    public class LogContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        public LogContext(DbContextOptions<LogContext> options) : base(options) { }

        public LogContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppSettingsDto.Settings.ConnectionStrings.LogDb);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("public");
            builder.ApplyConfiguration(new LogMap());
        }
    }
}
