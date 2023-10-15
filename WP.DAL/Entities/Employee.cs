using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.DAL.Entities
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Customer> Customers { get; set; }
        public List<BusinessLocation> BusinessLocations { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
