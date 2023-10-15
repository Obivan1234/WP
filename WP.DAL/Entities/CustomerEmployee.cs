using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.DAL.Entities
{
    public class CustomerEmployee
    {
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
