using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Rola
    {
        public Rola()
        {
            UposlenikRolas = new HashSet<UposlenikRola>();
        }

        public int RolaId { get; set; }
        public string? Naziv { get; set; }

        public virtual ICollection<UposlenikRola> UposlenikRolas { get; set; }
    }
}
