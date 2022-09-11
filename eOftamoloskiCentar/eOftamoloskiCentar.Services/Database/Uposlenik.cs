using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Uposlenik
    {
        public Uposlenik()
        {
            DijagnozaUposleniks = new HashSet<DijagnozaUposlenik>();
            Novosts = new HashSet<Novost>();
            UposlenikRolas = new HashSet<UposlenikRola>();
        }

        public int UposlenikId { get; set; }
        public int? OsobaId { get; set; }
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public string? Zvanje { get; set; }

        public virtual Osoba? Osoba { get; set; }
        public virtual ICollection<DijagnozaUposlenik> DijagnozaUposleniks { get; set; }
        public virtual ICollection<Novost> Novosts { get; set; }
        public virtual ICollection<UposlenikRola> UposlenikRolas { get; set; }
    }
}
