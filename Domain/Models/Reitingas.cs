using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Domain.Models
{
    public partial class Reitingas
    {
        public int? Ivertinimas { get; set; }
        public DateTime? IvertinimoData { get; set; }
        public int IdReitingas { get; set; }
        public int FkSportininkasId { get; set; }
        public int FkTrenerisId { get; set; }

        public virtual Sportininkas FkSportininkas { get; set; }
        public virtual Treneris FkTreneris { get; set; }
    }
}
