using AutoMapper;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Profiles
{
    public class CompetitionParticipantProfile : Profile
    {
        public CompetitionParticipantProfile()
        {
            CreateMap<VarzybuDalyvis, CompetitionParticipantGetModel>(); 
        }
        
    }
}