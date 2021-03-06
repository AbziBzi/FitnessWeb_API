using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessWeb_API.Mapping.Models
{
    public class CompetitionCreateModel
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
        public int FkNaudotojasId { get; set; }
    }
}