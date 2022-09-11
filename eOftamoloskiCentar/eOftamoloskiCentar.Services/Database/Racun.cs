using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Racun
    {
        public Racun()
        {
            StavkaRacunas = new HashSet<StavkaRacuna>();
        }

        public int RacunId { get; set; }
        public int? BrojRacuna { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? Iznos { get; set; }
        public int? KlijentId { get; set; }

        public virtual Klijent? Klijent { get; set; }
        public virtual ICollection<StavkaRacuna> StavkaRacunas { get; set; }
    }
}
