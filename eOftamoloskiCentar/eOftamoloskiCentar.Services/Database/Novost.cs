using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Novost
    {
        public int NovostId { get; set; }
        public string? Naslov { get; set; }
        public string? Sadrzaj { get; set; }
        public DateTime? DatumObjave { get; set; }
        public int? UposlenikId { get; set; }

        public virtual Uposlenik? Uposlenik { get; set; }
    }
}
