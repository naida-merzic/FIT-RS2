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
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public int? SpolId { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? KorisnickoIme { get; set; }
        public string? Email { get; set; }
        public bool? Status { get; set; }
        public int? KorisnickiRacunId { get; set; }

        public virtual KorisnickiRacun? KorisnickiRacun { get; set; }
        public virtual Spol? Spol { get; set; }
        public virtual ICollection<DijagnozaUposlenik> DijagnozaUposleniks { get; set; }
        public virtual ICollection<Novost> Novosts { get; set; }
        public virtual ICollection<UposlenikRola> UposlenikRolas { get; set; }
    }
}
