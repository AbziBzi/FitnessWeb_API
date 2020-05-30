using System;
using System.ComponentModel.DataAnnotations;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Models
{
    public class PerformingExerciseCreateModel
    {
        [Required]
        public int? Kiekis { get; set; }
        public string VaizdoIrasasUrl { get; set; }
        [Required]
        public int FkSportininkasId { get; set; }
        [Required]
        public int FkPratimasId { get; set; }
    }
}