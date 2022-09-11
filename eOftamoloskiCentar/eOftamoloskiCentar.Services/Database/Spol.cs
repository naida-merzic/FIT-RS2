using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Spol
    {
        public Spol()
        {
            Osobas = new HashSet<Osoba>();
        }

        public int SpolId { get; set; }
        public string? Naziv { get; set; }

        public virtual ICollection<Osoba> Osobas { get; set; }
    }
}
