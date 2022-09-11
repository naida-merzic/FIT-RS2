using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Termin
    {
        public int TerminId { get; set; }
        public DateTime? DatumTermina { get; set; }
        public double? Dioptrija { get; set; }
        public string? VrstaPregleda { get; set; }
        public int? KlijentId { get; set; }

        public virtual Klijent? Klijent { get; set; }
    }
}
