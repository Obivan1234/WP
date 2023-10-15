using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WP.DAL.Entities;

namespace WP.DAL.EntityTypeConfigurations
{
    public class BusinessLocationConfiguration : IEntityTypeConfiguration<BusinessLocation>
    {
        public void Configure(EntityTypeBuilder<BusinessLocation> builder)
        {
            builder.HasKey(e => e.BusinessLocationId);

            builder.ToTable("BusinessLocations");

            builder.Property(e => e.BusinessLocationId)
                .HasColumnName("BusinessLocationId");

            builder.Property(e => e.RowVersion)
                .IsRowVersion();

            builder.Property(e => e.Name)
                .HasDefaultValue(null)
                .HasColumnName("Name");

            builder.Property(e => e.Address)
                .HasDefaultValue(null)
                .HasColumnName("Address");

            builder.Property(e => e.TelephoneNumber)
                .HasDefaultValue(null)
                .HasColumnName("TelephoneNumber");

            builder.HasOne(e => e.Customer)
               .WithMany(x => x.BusinessLocations)
               .HasForeignKey(x => x.CustomerId);

            builder.HasMany(e => e.Employees)
                .WithMany(e => e.BusinessLocations)
                .UsingEntity(
                    "BusinessLocationEmployee",
                    l => l.HasOne(typeof(BusinessLocation)).WithMany().HasForeignKey("BusinessLocationId").HasPrincipalKey(nameof(BusinessLocation.BusinessLocationId)),
                    r => r.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.EmployeeId)),
                    j => j.HasKey("EmployeeId", "BusinessLocationId"));
        }
    }
}
