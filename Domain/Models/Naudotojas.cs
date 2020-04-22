using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Domain.Models
{
    public partial class Naudotojas
    {
        public Naudotojas()
        {
            Varzybos = new HashSet<Varzybos>();
            VarzybuDalyvis = new HashSet<VarzybuDalyvis>();
            ZinuteFkGavejas = new HashSet<Zinute>();
            ZinuteFkSiuntejas = new HashSet<Zinute>();
        }

        public string Pavarde { get; set; }
        public string Vardas { get; set; }
        public string Epastas { get; set; }
        public string Slaptazodis { get; set; }
        public DateTime? RegistracijosData { get; set; }
        public DateTime? PaskutinioPrisijungimoData { get; set; }
        public int? Lygis { get; set; }
        public int IdNaudotojas { get; set; }

        public virtual Sportininkas Sportininkas { get; set; }
        public virtual Treneris Treneris { get; set; }
        public virtual ICollection<Varzybos> Varzybos { get; set; }
        public virtual ICollection<VarzybuDalyvis> VarzybuDalyvis { get; set; }
        public virtual ICollection<Zinute> ZinuteFkGavejas { get; set; }
        public virtual ICollection<Zinute> ZinuteFkSiuntejas { get; set; }
    }
}
