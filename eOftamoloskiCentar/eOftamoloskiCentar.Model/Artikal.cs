using Microsoft.ML.Data;
using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Model
{
    public partial class Artikal
    {
        public int ArtikalId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        
        [ColumnName("Label")]
        public decimal Cijena { get; set; }
        public int? VrstaArtiklaId { get; set; }
        public string StateMachine { get; set; }
        public string Sifra { get; set; }
        public string NazivArtikla { get; set; }
        public byte[] Slika { get; set; }



        public VrstaArtikla VrstaArtikla { get; set; } 

        //public virtual ICollection<StavkaRacuna> StavkaRacunas { get; set; }
    }
}
