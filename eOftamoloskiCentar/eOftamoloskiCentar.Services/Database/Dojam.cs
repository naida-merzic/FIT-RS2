using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Dojam
    {
        public int DojamId { get; set; }
        public bool? IsLiked { get; set; }
        public int? ArtikalId { get; set; }
        public int? KlijentId { get; set; }

        public virtual Artikal? Artikal { get; set; }
        public virtual Klijent? Klijent { get; set; }
    }
}
