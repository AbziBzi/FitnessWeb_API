using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Models
{
    public partial class Treneris
    {
        public Treneris()
        {
            AtliekamasPratimas = new HashSet<AtliekamasPratimas>();
            Reitingas = new HashSet<Reitingas>();
            SportoPrograma = new HashSet<SportoPrograma>();
        }

        public int IdNaudotojas { get; set; }

        public virtual Naudotojas IdNaudotojasNavigation { get; set; }
        public virtual ICollection<AtliekamasPratimas> AtliekamasPratimas { get; set; }
        public virtual ICollection<Reitingas> Reitingas { get; set; }
        public virtual ICollection<SportoPrograma> SportoPrograma { get; set; }
    }
}
