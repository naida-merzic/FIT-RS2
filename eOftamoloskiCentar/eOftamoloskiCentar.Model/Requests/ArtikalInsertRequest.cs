using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class ArtikalInsertRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal? Cijena { get; set; }
    }
}
