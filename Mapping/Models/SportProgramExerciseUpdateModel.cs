using System.ComponentModel.DataAnnotations;

namespace FitnessWeb_API.Mapping.Models
{
    public class SportProgramExerciseUpdateModel
    {
        public int? Setai { get; set; }
        public int? Kartojimai { get; set; }
        [Required]
        public int IdSportoProgramosPratimas { get; set; }
        public int? FkSportoProgramaId { get; set; }
        public int? FkPratimasId { get; set; }
    }
}