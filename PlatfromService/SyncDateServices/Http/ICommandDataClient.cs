using PlatfromService.Dtos;

namespace PlatfromService.SyncDateServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatfromToCommand(PlatformReadDto platfrom);
        
    }
}