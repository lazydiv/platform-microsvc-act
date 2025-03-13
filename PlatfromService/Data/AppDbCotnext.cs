using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PlatfromService.Models;

namespace PlatfromService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Constructor logic if needed
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}