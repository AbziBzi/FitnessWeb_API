using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Models
{
    public partial class AtliekamasPratimas
    {
        public int? Kiekis { get; set; }
        public int? Ivertinimas { get; set; }
        public string VaizdoIrasasUrl { get; set; }
        public DateTime? IvertinimoData { get; set; }
        public int IdAtliekamasPratimas { get; set; }
        public int? FkTrenerisId { get; set; }
        public int FkSportininkasId { get; set; }
        public int FkPratimasId { get; set; }

        public virtual Pratimas FkPratimas { get; set; }
        public virtual Sportininkas FkSportininkas { get; set; }
        public virtual Treneris FkTreneris { get; set; }
    }
}
