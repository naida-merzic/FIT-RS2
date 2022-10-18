using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Model
{
    public partial class Termin
    {
        public int TerminId { get; set; }
        public DateTime DatumTermina { get; set; }
        public double? Dioptrija { get; set; }
        public string VrstaPregleda { get; set; }
        public int KlijentId { get; set; }

        public string FullName { get; set; }

        public Klijent Klijent { get; set; }
       
    }
}
