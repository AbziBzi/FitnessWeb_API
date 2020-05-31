using System;

namespace FitnessWeb_API.Mapping.Models
{
    public class PerformedExerciseRatingCreateModel
    {
        public int? Ivertinimas { get; set; }
        public DateTime? IvertinimoData { get; set; }
        public int? FkTrenerisId { get; set; }

    }
}