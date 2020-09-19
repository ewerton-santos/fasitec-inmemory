using AutoMapper;
using Fasitec.Business.Dto;
using Fasitec.Business.Entities;

namespace Data.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<User, UserInput>().ReverseMap();
            CreateMap<User, UserOutput>().ReverseMap();
            CreateMap<UserInput, UserOutput>().ReverseMap();
        }
    }
}