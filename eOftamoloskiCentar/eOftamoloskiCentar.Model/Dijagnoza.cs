using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model
{
    public partial class Dijagnoza
    {
        public int DijagnozaId { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }

        public int KlijentId { get; set; }

        public Klijent Klijent { get; set; }
        //public virtual ICollection<DijagnozaUposlenik> DijagnozaUposleniks { get; set; }
    }
}
