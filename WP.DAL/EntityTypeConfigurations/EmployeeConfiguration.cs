using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WP.DAL.Entities;

namespace WP.DAL.EntityTypeConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            builder.ToTable("Employees");

            builder.Property(e => e.EmployeeId)
                .HasColumnName("employee_id");

            builder.Property(e => e.RowVersion)
                .IsRowVersion();

            builder.Property(e => e.Email)
                .HasDefaultValue(null)
                .HasColumnName("Email");

            builder.Property(e => e.PhoneNumber)
                .HasDefaultValue(null)
                .HasColumnName("PhoneNumber");

            builder.Property(e => e.FirstName)
                .HasDefaultValue(null)
                .HasColumnName("FirstName");

            builder.Property(e => e.LastName)
                .HasDefaultValue(null)
                .HasColumnName("LastName");
        }
    }
}
