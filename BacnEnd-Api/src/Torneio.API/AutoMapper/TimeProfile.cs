using AutoMapper;
using Torneio.API.Models.Dtos;
using Torneio.API.Models.Entities;

namespace Torneio.API.AutoMapper
{
    public class TimeProfile : Profile
    {
        public TimeProfile()
        {
            CreateMap<Time, ListTimeDto>();
            CreateMap<Time, CreateTimeDto>().ReverseMap();
            CreateMap<Time, DetailTimeDto>().ReverseMap();
        }
    }
}
