using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.SearchObjects
{
    public class TerminSearchObject:BaseSearchObject
    {
        public string Ime { get; set; }

        public string VrstaPregleda { get; set; }
        public int? KlijentId { get; set; }
    }
}
