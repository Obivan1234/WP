using Microsoft.AspNetCore.Mvc;
using WP.Common;
using WP.Common.Models;

namespace WP.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private readonly ResponseResolver _resolver;
        public BaseApiController(ResponseResolver resolver)
        {
            _resolver = resolver;
        }
        public IActionResult ResolveResponse<T>(ResponseObject<T> result) where T : class
        {
            return _resolver.ResolveResponse(result);
        }
    }
}
