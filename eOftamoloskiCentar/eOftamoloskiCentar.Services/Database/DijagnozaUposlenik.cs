using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class DijagnozaUposlenik
    {
        public int DijagnozaUposlenikId { get; set; }
        public int? UposlenikId { get; set; }
        public int? DijagnozaId { get; set; }

        public virtual Dijagnoza? Dijagnoza { get; set; }
        public virtual Uposlenik? Uposlenik { get; set; }
    }
}
