using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WP.BLL.Interfaces;
using WP.Common;
using WP.Common.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WP.API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(ResponseResolver resolver, IEmployeeService employeeService) : base(resolver)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("/employee")]
        [SwaggerResponse(Status200OK, description: "Success", typeof(ResponseObject<IdDto<long>>))]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
        {
            ResponseObject<IdDto<long>> result = await _employeeService.CreateEmployee(request);

            return ResolveResponse(result);
        }

        [HttpPost]
        [Route("/employee-location")]
        [SwaggerResponse(Status200OK, description: "Success", typeof(ResponseObject<IdDto<long>>))]
        public async Task<IActionResult> CreateEmployeeLocation([FromBody] CreateEmployeeLocationRequest request)
        {
            ResponseObject<IdDto<long>> result = await _employeeService.CreateEmployeeLocation(request);

            return ResolveResponse(result);
        }
    }
}
