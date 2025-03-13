using Microsoft.EntityFrameworkCore;
using PlatfromService.Models;

namespace PlatfromService.Data 
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;
        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        // private
        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Platforms.Add(plat);

        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id)!; 
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
   

        void IPlatformRepo.DeletePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Platforms.Remove(plat);
        }
    }
}