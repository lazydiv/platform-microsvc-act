using AutoMapper;
using PlatfromService.Dtos;
using PlatfromService.Models;

namespace PlatfromService.Profiles
{
     public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
        
    }
}