using AbrasNigeria.Data.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AbrasNigeria.Data.Utils
{
    public static class DbInitializer
    {
        public static void DoMigration(IApplicationBuilder app)
        {
            AppDbContext appDbContext = app.ApplicationServices.GetRequiredService<AppDbContext>();
            PartsBookDbContext partsBookDbContext = app.ApplicationServices.GetRequiredService<PartsBookDbContext>();

            //context.Database.EnsureDeleted();
            //appDbContext.Database.EnsureCreated();
            //partsBookDbContext.Database.EnsureCreated();

            appDbContext.Database.Migrate();
        }

    }
}
