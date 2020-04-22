using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Domain.Models
{
    public partial class SportoPrograma
    {
        public SportoPrograma()
        {
            SportoProgramosPratimas = new HashSet<SportoProgramosPratimas>();
        }

        public string Pavadinimas { get; set; }
        public string Aprasas { get; set; }
        public string NuotraukosUrl { get; set; }
        public int IdSportoPrograma { get; set; }
        public int FkTrenerisId { get; set; }

        public virtual Treneris FkTreneris { get; set; }
        public virtual ICollection<SportoProgramosPratimas> SportoProgramosPratimas { get; set; }
    }
}
