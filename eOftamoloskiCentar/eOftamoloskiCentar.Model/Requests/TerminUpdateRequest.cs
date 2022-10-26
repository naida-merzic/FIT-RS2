using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class TerminUpdateRequest
    {
        public DateTime DatumTermina { get; set; }
        public double? Dioptrija { get; set; }
        public string VrstaPregleda { get; set; }
        public int KlijentId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Klijent Klijent { get; set; }
    }
}
