using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WP.BLL.Interfaces;
using WP.Common;
using WP.Common.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WP.API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(
            ResponseResolver resolver,
            ICustomerService customerService) : base(resolver)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("/customers/{customerId}")]
        [SwaggerResponse(Status200OK, description: "Success", typeof(ResponseObject<CustomerDetailsDto>))]
        public async Task<IActionResult> GetCustomerDetails([FromRoute(Name = "customerId")] string customerId)
        {
            ResponseObject<CustomerDetailsDto> result = await _customerService.GetCustomerByIdAsync(customerId);

            return ResolveResponse(result);
        }

        [HttpPost]
        [Route("/customers")]
        [SwaggerResponse(Status200OK, description: "Success", typeof(ResponseObject<IdDto<long>>))]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            ResponseObject<IdDto<long>> result = await _customerService.CreateCustomer(request.CustomerName, request.EployeesIds);

            return ResolveResponse(result);
        }
    }
}
