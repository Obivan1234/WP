using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;
using WP.BLL.Implementation;
using WP.BLL.Interfaces;
using WP.Common;
using WP.DAL.Context;

namespace WP.API
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.RegisterResponseWrapper();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBusinessLocationService, BusinessLocationService>(); 
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddAutoMapper(typeof(ServiceExtensions).Assembly);

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WorkPlaceContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });
            });

            return services;
        }
    }
}
