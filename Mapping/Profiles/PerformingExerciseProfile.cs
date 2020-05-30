using AutoMapper;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Profiles
{
    public class PerformingExerciseProfile : Profile
    {
        public PerformingExerciseProfile()
        {
            CreateMap<AtliekamasPratimas, PerformingExerciseGetModel>()
                .ForMember(dest => dest.FkPratimas, 
                    opt => opt.MapFrom(src => src.FkPratimas))
                .ForMember(dest => dest.FkTreneris, 
                    opt => opt.MapFrom(src => src.FkTreneris));
            CreateMap<AtliekamasPratimas, PerformingExerciseCreateModel>();
            CreateMap<PerformingExerciseCreateModel, AtliekamasPratimas>();
        }
    }
}