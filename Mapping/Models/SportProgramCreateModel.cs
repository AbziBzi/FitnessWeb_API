using System.Collections.Generic;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Models
{
    public class SportProgramCreateModel
    {
        public string Pavadinimas { get; set; }
        public string Aprasas { get; set; }
        public string NuotraukosUrl { get; set; }
        public int FkTrenerisId { get; set; }
        public virtual ICollection<SportProgramExerciseCreateModel> SportoProgramosPratimas { get; set; }
    }
}