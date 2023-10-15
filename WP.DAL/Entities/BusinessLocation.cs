using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.DAL.Entities
{
    public class BusinessLocation
    {
        public long BusinessLocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Employee> Employees { get; set; }
        public byte[] RowVersion { get; set; }
    }

}
