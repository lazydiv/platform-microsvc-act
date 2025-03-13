using Microsoft.EntityFrameworkCore;
using PlatfromService.Models;

namespace PlatfromService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
            }

        }

        private static void SeedData(AppDbContext? appDbContext, bool isProduction)
        {

            if (appDbContext != null)
            {
                Console.WriteLine("--> Attempting to apply Migrations...");
                try
                {
                    appDbContext.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"--> Could not run Migrations: {e.Message}");
                }
            }

            if (appDbContext != null && !appDbContext.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                appDbContext.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" },
                    new Platform() { Name = "Postgres", Publisher = "Postgres", Cost = "Free" },
                    new Platform() { Name = "Docker", Publisher = "Docker", Cost = "Free" },
                    new Platform() { Name = "Azure DevOps", Publisher = "Microsoft", Cost = "Paid" }

                );
                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }

    }
}