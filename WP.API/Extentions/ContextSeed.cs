using Microsoft.EntityFrameworkCore;
using WP.DAL.Context;

namespace WP.API.Extentions
{
    public static class ContextSeed
    {
        public static void MigrationInitialization(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<WorkPlaceContext>();

            context.Database.Migrate();
            
        }
    }
}
