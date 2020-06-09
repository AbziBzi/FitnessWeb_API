using System.ComponentModel.DataAnnotations;

namespace FitnessWeb_API.Mapping.Models
{
    public class PriceIntervalModel
    {
        [Required]
        public int Min { get; set; }
        [Required]
        public int Max { get; set; }
    }
}