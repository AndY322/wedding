using AutoMapper;
using DomainModel.DTO;
using DomainModel.Models;

namespace WebApplication.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Survey, SurveyDTO>();
            CreateMap<SurveyDTO, Survey>()
                .ForMember(x => x.User, x => x.Ignore());
        }
    }
}