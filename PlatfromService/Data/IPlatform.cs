using PlatfromService.Models;

namespace PlatfromService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform plat);
        
        void DeletePlatform(Platform plat);
        
    }
}