using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class VrstaArtikla
    {
        public VrstaArtikla()
        {
            Artikals = new HashSet<Artikal>();
        }

        public int VrstaArtiklaId { get; set; }
        public string? NazivArtikla { get; set; }

        public virtual ICollection<Artikal> Artikals { get; set; }
    }
}
