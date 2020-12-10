using AutoMapper;
using TimeStamp.Application.ViewModels;
using TimeStamp.Infrastructure.Contracts;

namespace TimeStamp.Application.ObjectMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DetailsBestStoriesResponse, DetailsBestStoriesVm>();
        }
    }
}
