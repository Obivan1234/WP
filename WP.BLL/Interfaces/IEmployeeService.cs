using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Common.Models;

namespace WP.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseObject<IdDto<long>>> CreateEmployee(CreateEmployeeRequest createEmployeeRequest);
        Task<ResponseObject<IdDto<long>>> CreateEmployeeLocation(CreateEmployeeLocationRequest createEmployeeRequest);
    }
}