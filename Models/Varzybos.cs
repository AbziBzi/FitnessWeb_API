using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Models
{
    public partial class Varzybos
    {
        public Varzybos()
        {
            VarzybuDalyvis = new HashSet<VarzybuDalyvis>();
        }

        public DateTime? PrasidejimoData { get; set; }
        public string Pavadinimas { get; set; }
        public string Vieta { get; set; }
        public string Aprasas { get; set; }
        public DateTime? PabaigosData { get; set; }
        public int IdVarzybos { get; set; }
        public int FkNaudotojasId { get; set; }

        public virtual Naudotojas FkNaudotojas { get; set; }
        public virtual ICollection<VarzybuDalyvis> VarzybuDalyvis { get; set; }
    }
}
