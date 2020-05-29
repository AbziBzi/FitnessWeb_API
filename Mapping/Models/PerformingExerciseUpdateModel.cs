using System.ComponentModel.DataAnnotations;

namespace FitnessWeb_API.Mapping.Models
{
    public class PerformingExerciseUpdateModel
    {
        [Required]
        public string VaizdoIrasasUrl { get; set; }

    }
}