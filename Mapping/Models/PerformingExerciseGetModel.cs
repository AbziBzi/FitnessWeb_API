using System;

namespace FitnessWeb_API.Mapping.Models
{
    public class PerformingExerciseGetModel
    {
        public int? Kiekis { get; set; }
        public int? Ivertinimas { get; set; }
        public string VaizdoIrasasUrl { get; set; }
        public DateTime? IvertinimoData { get; set; }
        public int IdAtliekamasPratimas { get; set; }
        public int FkTrenerisId { get; set; }
        public int FkSportininkasId { get; set; }
        public int FkPratimasId { get; set; }

        public virtual ExerciseGetModel FkPratimas { get; set; }
        public virtual CoachGetModel FkTreneris { get; set; }
    }
}