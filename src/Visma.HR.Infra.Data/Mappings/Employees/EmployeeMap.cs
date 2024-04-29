using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visma.HR.Domain.Entities.Employees;

namespace Visma.HR.Infra.Data.Mappings.Employees
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(c => c.FirstName)
                   .HasColumnName("first_name")
                   .HasColumnType("VARCHAR(50)")
                   .IsRequired();

            builder.Property(c => c.LastName)
                   .HasColumnName("last_name")
                   .HasColumnType("VARCHAR(50)")
                   .IsRequired();

            builder.Property(c => c.BirthDate)
                   .HasColumnName("birth_date")
                   .IsRequired();

            builder.Property(c => c.EmploymentDate)
                   .HasColumnName("employment_date")
                   .IsRequired();

            builder.Property(c => c.CurrentlySalary)
                   .HasColumnName("currently_salary")
                   .IsRequired();

            builder.Property(c => c.Role)
                   .HasColumnName("role")
                   .IsRequired();

            builder.Property(c => c.HomeAddress)
                   .HasColumnName("home_address")
                   .HasColumnType("VARCHAR(150)")
                   .IsRequired();

            builder.Property(c => c.BossId)
                   .HasColumnName("boss_id");
        }
    }
}
