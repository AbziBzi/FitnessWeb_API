using System;
using System.Collections.Generic;

namespace FitnessWeb_API.Domain.Models
{
    public partial class VarzybuDalyvis
    {
        public int FkNaudotojasId { get; set; }
        public int FkVarzybosId { get; set; }

        public virtual Naudotojas FkNaudotojas { get; set; }
        public virtual Varzybos FkVarzybos { get; set; }
    }
}
