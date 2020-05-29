using AutoMapper;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Profiles
{
    public class CoachProfile : Profile
    {
        public CoachProfile()
        {
            CreateMap<Treneris, CoachGetModel>()
                .ForMember(dest => dest.Naudotojas,
                    opt => opt.MapFrom(src => src.IdNaudotojasNavigation));
        }
    }
}