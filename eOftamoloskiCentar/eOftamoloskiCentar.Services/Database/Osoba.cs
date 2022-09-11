using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class Osoba
    {
        public Osoba()
        {
            Klijents = new HashSet<Klijent>();
            Uposleniks = new HashSet<Uposlenik>();
        }

        public int OsobaId { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public int? SpolId { get; set; }

        public virtual Spol? Spol { get; set; }
        public virtual ICollection<Klijent> Klijents { get; set; }
        public virtual ICollection<Uposlenik> Uposleniks { get; set; }
    }
}
