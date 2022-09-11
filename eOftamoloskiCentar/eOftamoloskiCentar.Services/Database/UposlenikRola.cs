using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class UposlenikRola
    {
        public int UposlenikRolaId { get; set; }
        public int? UposlenikId { get; set; }
        public int? RolaId { get; set; }
        public DateTime? DatumIzmjene { get; set; }

        public virtual Rola? Rola { get; set; }
        public virtual Uposlenik? Uposlenik { get; set; }
    }
}
