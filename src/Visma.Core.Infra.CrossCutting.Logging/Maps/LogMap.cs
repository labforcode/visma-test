using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visma.Core.Infra.CrossCutting.Logging.Models;

namespace Visma.Core.Infra.CrossCutting.Logging.Maps
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("logs");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(c => c.Message)
                   .HasColumnName("message")
                   .IsRequired();

            builder.Property(c => c.StackTrace)
                   .HasColumnName("stack_trace")
                   .IsRequired();

            builder.Property(c => c.InputDate)
                   .HasColumnName("input_date")
                   .IsRequired();
        }
    }
}
