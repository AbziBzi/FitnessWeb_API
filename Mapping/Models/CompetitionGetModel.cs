using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Models
{
    public class CompetitionGetModel
    {
        [Required]
        public DateTime? PrasidejimoData { get; set; }
        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public string Vieta { get; set; }
        public string Aprasas { get; set; }
        [Required]
        public DateTime? PabaigosData { get; set; }
        [Required]
        public int IdVarzybos { get; set; }
        [Required]
        public int FkNaudotojasId { get; set; }

        public virtual ICollection<CompetitionParticipantGetModel> VarzybuDalyvis { get; set; }
        public virtual UserGetForCompetitionModel Naudotojas { get; set; }
    }
}