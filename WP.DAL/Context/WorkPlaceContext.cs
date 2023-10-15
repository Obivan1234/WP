using Microsoft.EntityFrameworkCore;
using WP.DAL.Entities;

namespace WP.DAL.Context
{
    public class WorkPlaceContext : DbContext
    {
        public WorkPlaceContext()
        {
            
        }
        public WorkPlaceContext(
            DbContextOptions<WorkPlaceContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BusinessLocation> BusinessLocations { get; set; }
    }
}
