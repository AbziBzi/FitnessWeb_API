using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Models
{
    public partial class Pratimas
    {
        public Pratimas()
        {
            AtliekamasPratimas = new HashSet<AtliekamasPratimas>();
            SportoProgramosPratimas = new HashSet<SportoProgramosPratimas>();
        }

        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public string NuotraukosUrl { get; set; }
        public int? Verte { get; set; }
        public int IdPratimas { get; set; }

        public virtual ICollection<AtliekamasPratimas> AtliekamasPratimas { get; set; }
        public virtual ICollection<SportoProgramosPratimas> SportoProgramosPratimas { get; set; }
    }
}
