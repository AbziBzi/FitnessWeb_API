using System.ComponentModel.DataAnnotations;

namespace FitnessWeb_API.Mapping.Models
{
    public class CompetitionParticipantGetModel
    {
        [Required]
        public int FkNaudotojasId { get; set; }
        [Required]
        public int FkVarzybosId { get; set; }

        [Required]
        public virtual UserGetForCompetitionModel FkNaudotojas { get; set; }
    }
}