using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Klijent
    {
        public Klijent()
        {
            Dijagnozas = new HashSet<Dijagnoza>();
            Racuns = new HashSet<Racun>();
            Termins = new HashSet<Termin>();
        }

        public int KlijentId { get; set; }
        public int? SpolId { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }

        public virtual Spol? Spol { get; set; }
        public virtual ICollection<Dijagnoza> Dijagnozas { get; set; }
        public virtual ICollection<Racun> Racuns { get; set; }
        public virtual ICollection<Termin> Termins { get; set; }
    }
}
