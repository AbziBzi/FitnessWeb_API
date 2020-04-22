using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Domain.Models
{
    public partial class SportoProgramosPratimas
    {
        public int? Setai { get; set; }
        public int? Kartojimai { get; set; }
        public int IdSportoProgramosPratimas { get; set; }
        public int FkSportoProgramaId { get; set; }
        public int FkPratimasId { get; set; }

        public virtual Pratimas FkPratimas { get; set; }
        public virtual SportoPrograma FkSportoPrograma { get; set; }
    }
}
