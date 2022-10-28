using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Klijent
    {
        public Klijent()
        {
            Dijagnozas = new HashSet<Dijagnoza>();
            Dojams = new HashSet<Dojam>();
            Racuns = new HashSet<Racun>();
            Termins = new HashSet<Termin>();
        }

        public int KlijentId { get; set; }
        public int? SpolId { get; set; }
        public int? KorisnickiRacunId { get; set; }

        public virtual KorisnickiRacun? KorisnickiRacun { get; set; }
        public virtual Spol? Spol { get; set; }
        public virtual ICollection<Dijagnoza> Dijagnozas { get; set; }
        public virtual ICollection<Dojam> Dojams { get; set; }
        public virtual ICollection<Racun> Racuns { get; set; }
        public virtual ICollection<Termin> Termins { get; set; }
    }
}
