using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Domain.Models
{
    public partial class Sportininkas
    {
        public Sportininkas()
        {
            AtliekamasPratimas = new HashSet<AtliekamasPratimas>();
            Reitingas = new HashSet<Reitingas>();
        }

        public int? AtliktuPratymuSkaicius { get; set; }
        public int? Taskai { get; set; }
        public int IdNaudotojas { get; set; }

        public virtual Naudotojas IdNaudotojasNavigation { get; set; }
        public virtual ICollection<AtliekamasPratimas> AtliekamasPratimas { get; set; }
        public virtual ICollection<Reitingas> Reitingas { get; set; }
    }
}
