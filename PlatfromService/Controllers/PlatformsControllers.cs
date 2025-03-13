using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatfromService.Data;
using PlatfromService.Dtos;
using PlatfromService.Models;
using PlatfromService.SyncDateServices.Http;

namespace PlatfromService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repostory;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _repostory = platformRepo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;

        }


        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatfroms()
        {
            Console.WriteLine("--> Getting Platforms...");
            var platformItems = _repostory.GetPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));

        }
        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platformItem = _repostory.GetPlatformById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _repostory.CreatePlatform(platformModel);
            _repostory.SaveChanges();
            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            try
            {
                await _commandDataClient.SendPlatfromToCommand(platformReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetPlatformById), new { platformReadDto.Id }, platformReadDto);
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePlatform(int id)
        {
            var platformModel = _repostory.GetPlatformById(id);
            if (platformModel == null)
            {
                return NotFound();
            }
            _repostory.DeletePlatform(platformModel);

            _repostory.SaveChanges();
            return NoContent();
        }
    }
}