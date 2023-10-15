using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Common.Models;

namespace WP.BLL.Interfaces
{
    public interface IBusinessLocationService
    {
        Task<ResponseObject<IdDto<long>>> CreateBusinessLocation(string customerId, BusinessLocationPostDto businessLocationPostDto);
        Task<ResponseObject<IdDto<long>>> UpdateLocationAsync(string locationId, JsonPatchDocument<LocationPatchDto> locationPatch);
    }
}
