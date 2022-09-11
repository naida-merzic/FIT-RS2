using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class OsobaUpsertRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public int? SpolId { get; set; }
    }
}
