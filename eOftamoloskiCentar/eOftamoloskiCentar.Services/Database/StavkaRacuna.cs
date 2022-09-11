using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class StavkaRacuna
    {
        public int StavkaRacunaId { get; set; }
        public int? RacunId { get; set; }
        public int? ArtikalId { get; set; }
        public int? Kolicina { get; set; }

        public virtual Artikal? Artikal { get; set; }
        public virtual Racun? Racun { get; set; }
    }
}
