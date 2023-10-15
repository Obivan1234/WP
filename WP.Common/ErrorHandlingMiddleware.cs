using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using WP.Common.Enums;
using WP.Common.Exceptions;
using WP.Common.Models;

namespace WP.Common
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;
        private ResponseHandler _responseHandler;
        private readonly JsonSerializerSettings _jsonSettings;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
            _jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public async Task Invoke(HttpContext context,
            ILogger<ErrorHandlingMiddleware> logger,
            ResponseHandler responseHandler)
        {
            try
            {
                _logger = logger;
                _responseHandler = responseHandler;

                await _next(context);
            }
            catch (ThirdPartyServiceException e)
            {
                await HandleThirdPartyErrorAsync(context,
                    e);
            }
            catch (Exception e)
            {
                await HandleInternalServerErrorAsync(context,
                    e);
            }
        }

        private Task HandleInternalServerErrorAsync(HttpContext context,
            Exception exception)
        {
            _logger.LogError(exception, null);

            ResponseObject<object> result = (_responseHandler ?? new ResponseHandler())
                .SetErrorCode(new ResponseObject<object>(), ErrorCode.InternalServerError);

            string errorResponseContent = JsonConvert.SerializeObject(result, _jsonSettings);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(errorResponseContent);
        }

        private Task HandleThirdPartyErrorAsync(HttpContext context,
            ThirdPartyServiceException thirdPartyServiceException)
        {
            _logger.LogError(thirdPartyServiceException, null);

            ResponseObject<object> result = (_responseHandler ?? new ResponseHandler())
                .SetErrorCode(new ResponseObject<object>(), ErrorCode.BadGateway);

            string errorResponseContent = JsonConvert.SerializeObject(result, _jsonSettings);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadGateway;

            return context.Response.WriteAsync(errorResponseContent);
        }
    }
}
