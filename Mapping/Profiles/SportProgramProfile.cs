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
            CreateMap<SportoPrograma, SportProgramCreateModel>();
            CreateMap<SportProgramCreateModel, SportoPrograma>();
            CreateMap<SportoPrograma, SportProgramUpdateModel>();
            CreateMap<SportProgramUpdateModel, SportoPrograma>();
            CreateMap<SportProgramExerciseCreateModel, SportoProgramosPratimas>();
            CreateMap<SportoProgramosPratimas, SportProgramExerciseCreateModel>();
            CreateMap<SportProgramExerciseUpdateModel, SportoProgramosPratimas>();
            CreateMap<SportoProgramosPratimas, SportProgramExerciseUpdateModel>();
        }
    }
}