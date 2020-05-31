using System;
using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Models
{
    public class PerformedExerciseRatingGetModel
    {
        public int? Ivertinimas { get; set; }
        public DateTime? IvertinimoData { get; set; }
        public int? FkTrenerisId { get; set; }
        public virtual CoachGetModel FkTreneris { get; set; }
    }
}