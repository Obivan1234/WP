using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Common.Enums;
using WP.Common.Models;

namespace WP.Common
{
    public class ResponseResolver
    {
        private readonly ILogger _logger;

        public ResponseResolver(ILogger<ResponseResolver> logger)
        {
            _logger = logger;
        }

        public IActionResult ResolveResponse<T>(ResponseObject<T> result) where T : class
        {
            if (!result.HasErrors())
            {
                return new OkObjectResult(result);
            }

            _logger?.LogWarning(JsonConvert.SerializeObject(result.Errors));

            List<int> codes = result.Errors.Select(x => x.Code).ToList();

            return new BadRequestObjectResult(result);
        }
    }
}
