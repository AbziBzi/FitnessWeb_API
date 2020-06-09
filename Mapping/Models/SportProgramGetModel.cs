using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Models
{
    public class SportProgramGetModel
    {
        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public string Aprasas { get; set; }
        public string NuotraukosUrl { get; set; }
        [Required]
        public int IdSportoPrograma { get; set; }

        public virtual CoachGetModel FkTreneris { get; set; }
        public virtual ICollection<SportProgramExerciseGetModel> SportoProgramosPratimas { get; set; }
    }
}