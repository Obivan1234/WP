using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Common.Models;

namespace WP.BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<ResponseObject<CustomerDetailsDto>> GetCustomerByIdAsync(string customerId);
        Task<ResponseObject<IdDto<long>>> CreateCustomer(string customerName, List<string> eployeesIds);
    }
}
