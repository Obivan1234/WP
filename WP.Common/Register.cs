
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WP.Common
{
    public static class Register
    {
        public static IApplicationBuilder UseResponseErrorMiddleware(this IApplicationBuilder builder,
        params object[] arguments)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>(args: arguments);
        }
        public static void RegisterResponseWrapper(this IServiceCollection services)
        {
            services.AddSingleton<ResponseHandler>();
            services.AddScoped<ResponseResolver>();
        }
    }
}
