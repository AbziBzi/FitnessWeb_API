using AutoMapper;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Profiles
{
    public class CompetitionProfile: Profile
    {
        public CompetitionProfile()
        {
            // Map Model to DTO

            CreateMap<Varzybos, CompetitionGetModel>()
                .ForMember(dest => dest.Naudotojas, 
                    opt => opt.MapFrom(src => src.FkNaudotojas))
                .ForMember(dest => dest.VarzybuDalyvis,
                    opt => opt.MapFrom(src => src.VarzybuDalyvis));
            CreateMap<Varzybos, CompetitionCreateModel>();
            

            // Map DTO to Model
            CreateMap<CompetitionCreateModel, Varzybos>();
            CreateMap<CompetitionUpdateModel, Varzybos>();
        }
    }
}