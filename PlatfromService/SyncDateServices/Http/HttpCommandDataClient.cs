

using System.Text;
using System.Text.Json;
using PlatfromService.Dtos;

namespace PlatfromService.SyncDateServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;


        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
    
        }

        public async Task SendPlatfromToCommand(PlatformReadDto platfrom)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platfrom),
                Encoding.UTF8,
                "application/json"
            );
            var res = await _httpClient.PostAsync($"{_config["CommandService"]}", httpContent);
            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine("Post to Command was OK!");
            }
            else
            {
                Console.WriteLine("Post to Command was not OK!");
            }
        }
    }
}