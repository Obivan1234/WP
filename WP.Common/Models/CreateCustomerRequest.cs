using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Common.Models
{
    public class CreateCustomerRequest
    {
        public string CustomerName { get; set; }
        public List<string> EployeesIds { get; set; }
    }
}
