using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visma.Domain.Entities.Addresses;

namespace Visma.Infra.Data.Mappings.Addresses
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("addresses");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .IsRequired();
            builder.Property(c => c.PostalCode)
                   .HasColumnName("postal_code")
                   .IsRequired();

            builder.Property(c => c.Number)
                   .HasColumnName("number")
                   .IsRequired();

            builder.Property(c => c.Street)
                   .HasColumnName("street")
                   .IsRequired();

            builder.Property(c => c.City)
                   .HasColumnName("city")
                   .IsRequired();

            builder.Property(c => c.State)
                   .HasColumnName("state")
                   .IsRequired();

            builder.Property(c => c.Country)
                   .HasColumnName("country")
                   .IsRequired();

            builder.Property(c => c.EmployeeId)
                   .HasColumnName("employee_id")
                   .IsRequired();
        }
    }
}
