﻿using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Artikal
    {
        public Artikal()
        {
            StavkaRacunas = new HashSet<StavkaRacuna>();
        }

        public int ArtikalId { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public decimal? Cijena { get; set; }
        public int? VrstaArtiklaId { get; set; }
        public string StateMachine { get; set; }

        public virtual VrstaArtikla? VrstaArtikla { get; set; }
        public virtual ICollection<StavkaRacuna> StavkaRacunas { get; set; }
    }
}
