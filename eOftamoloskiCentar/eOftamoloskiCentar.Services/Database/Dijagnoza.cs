using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Dijagnoza
    {
        public Dijagnoza()
        {
            DijagnozaUposleniks = new HashSet<DijagnozaUposlenik>();
        }

        public int DijagnozaId { get; set; }
        public string? Naziv { get; set; }
        public string? Sadrzaj { get; set; }
        public int? KlijentId { get; set; }

        public virtual Klijent? Klijent { get; set; }
        public virtual ICollection<DijagnozaUposlenik> DijagnozaUposleniks { get; set; }
    }
}
