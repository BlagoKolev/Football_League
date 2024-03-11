using FootballLeague.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FootballLeague.Extensions
{
    public static class WebApplicationExtension
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            var db = services.GetRequiredService<LeagueDbContext>();
            db.Database.Migrate();

            return app;
        }
    }
}
