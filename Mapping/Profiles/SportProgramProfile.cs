using AutoMapper;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Profiles
{
    public class SportProgramProfile : Profile
    {
        public SportProgramProfile()
        {
            CreateMap<SportoPrograma,SportProgramGetModel>()
                .ForMember(dest => dest.FkTreneris,
                    opt => opt.MapFrom(src => src.FkTreneris)) 
                .ForMember(dest => dest.SportoProgramosPratimas,
                    opt => opt.MapFrom(src => src.SportoProgramosPratimas));
            CreateMap<Treneris, CoachGetModel>();
        }
    }
}