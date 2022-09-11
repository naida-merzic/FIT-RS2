using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Model
{
    public partial class Uposlenik
    {
        public int UposlenikId { get; set; }
        public int OsobaId { get; set; }
        public string LozinkaHash { get; set; } 
        public string LozinkaSalt { get; set; }
        public string Zvanje { get; set; }

        //public virtual Osoba? Osoba { get; set; }
        //public virtual ICollection<DijagnozaUposlenik> DijagnozaUposleniks { get; set; }
        // public virtual ICollection<Novost> Novosts { get; set; }
        public virtual ICollection<UposlenikRola> UposlenikRolas { get; set; }
    }
}
