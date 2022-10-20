using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class RacunUpdateRequest
    {
        public int? BrojRacuna { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? Iznos { get; set; }
        public int? KlijentId { get; set; }
    }
}
