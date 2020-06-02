using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Models
{
    public class SportProgramUpdateModel
    {
        [Required]
        public string Pavadinimas { get; set; }
        public string Aprasas { get; set; }
        public string NuotraukosUrl { get; set; }
        public int IdSportoPrograma { get; set; }
        public virtual ICollection<SportProgramExerciseUpdateModel> SportoProgramosPratimas { get; set; }
    }
}