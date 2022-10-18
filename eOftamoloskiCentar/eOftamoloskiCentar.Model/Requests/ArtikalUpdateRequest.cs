using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public  class ArtikalUpdateRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public int? VrstaArtiklaId { get; set; }
        public string StateMachine { get; set; }
        public string Sifra { get; set; }
    }
}
