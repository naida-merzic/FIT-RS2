using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Model
{
    public partial class Klijent
    {
        public int KlijentId { get; set; }
        public int SpolId { get; set; }
        public Spol Spol { get; set; }

        public virtual Model.KorisnickiRacun KorisnickiRacun { get; set; }

        
    }
}
