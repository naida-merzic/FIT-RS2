using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class KlijentUpdateRequest
    {
        public int SpolId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}
