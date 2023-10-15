using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Common.Models
{
    public class CreateEmployeeLocationRequest
    {
        public string EmployeeId { get; set; }
        public List<string> Locationids { get; set; }
    }
}
