using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WP.DAL.Entities;

namespace WP.DAL.EntityTypeConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.CustomerId);

            builder.ToTable("Customers");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerId");

            builder.Property(e => e.RowVersion)
                .IsRowVersion();

            builder.Property(e => e.Name)
                .HasDefaultValue(null)
                .HasColumnName("Name");

            builder.HasMany(e => e.Employees)
                .WithMany(e => e.Customers)
                .UsingEntity(
                    "CustomerEmployee",
                    l => l.HasOne(typeof(Customer)).WithMany().HasForeignKey("CustomerId").HasPrincipalKey(nameof(Customer.CustomerId)),
                    r => r.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.EmployeeId)),
                    j => j.HasKey("EmployeeId", "CustomerId"));
        }
    }
}
