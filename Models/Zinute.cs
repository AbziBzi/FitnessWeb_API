using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Models
{
    public partial class Zinute
    {
        public Zinute()
        {
            InverseFkZinute = new HashSet<Zinute>();
        }

        public string Tekstas { get; set; }
        public DateTime? IssiuntimoLaikas { get; set; }
        public int IdZinute { get; set; }
        public int? FkZinuteId { get; set; }
        public int FkSiuntejasId { get; set; }
        public int FkGavejasId { get; set; }

        public virtual Naudotojas FkGavejas { get; set; }
        public virtual Naudotojas FkSiuntejas { get; set; }
        public virtual Zinute FkZinute { get; set; }
        public virtual ICollection<Zinute> InverseFkZinute { get; set; }
    }
}
