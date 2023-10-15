using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.DAL.Entities
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public List<BusinessLocation> BusinessLocations { get; set; }
        public List<Employee> Employees { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
