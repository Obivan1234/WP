using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WP.BLL.Implementation;
using WP.BLL.Interfaces;
using WP.Common;
using WP.Common.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WP.API.Controllers
{
    public class BusinessLocationController : BaseApiController
    {
        private readonly IBusinessLocationService _businessLocationService;
        public BusinessLocationController(
            ResponseResolver resolver, 
            IBusinessLocationService businessLocationService) : base(resolver)
        {
            _businessLocationService = businessLocationService;
        }

        [HttpPost]
        [Route("/business-location/{customerId}")]
        [SwaggerResponse(Status200OK, description: "Success", typeof(ResponseObject<IdDto<long>>))]
        public async Task<IActionResult> CreateBusinessLocation(
            [FromRoute(Name = "customerId")] string customerId, BusinessLocationPostDto businessLocationPostDto)
        {
            ResponseObject<IdDto<long>> result = await _businessLocationService.CreateBusinessLocation(customerId, businessLocationPostDto);

            return ResolveResponse(result);
        }

        [HttpPatch("/business-location/{locationId}")]
        [SwaggerResponse(Status200OK, description: "Success", typeof(ResponseObject<IdDto<long>>))]
        public async Task<IActionResult> UpdateVehicle([FromBody] JsonPatchDocument<LocationPatchDto> locationPatch,
        [FromRoute] string locationId)
        {
            ResponseObject<IdDto<long>> result = await _businessLocationService.UpdateLocationAsync(locationId, locationPatch);

            return ResolveResponse(result);
        }
    }
}
