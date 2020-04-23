using System.ComponentModel.DataAnnotations;

namespace FitnessWeb_API.Mapping.Models
{
    public class UserGetForCompetitionModel
    {
        [Required]
        public string Pavarde { get; set; }
        [Required]
        public string Vardas { get; set; }
        [Required]
        public int? Lygis { get; set; }
        [Required]
        public int IdNaudotojas { get; set; }
    }
}