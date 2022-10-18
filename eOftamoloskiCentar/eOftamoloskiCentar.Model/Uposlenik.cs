using System;
using System.Collections.Generic;
using System.Linq;


namespace eOftamoloskiCentar.Model
{
    public partial class Uposlenik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int UposlenikId { get; set; }
        public string LozinkaHash { get; set; } 
        public string LozinkaSalt { get; set; }
        public int SpolId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string RoleNames => string.Join(", ", UposlenikRolas?.Select(x => x.Rola?.Naziv)?.ToList());

        //public virtual Osoba? Osoba { get; set; }
        //public virtual ICollection<DijagnozaUposlenik> DijagnozaUposleniks { get; set; }
        // public virtual ICollection<Novost> Novosts { get; set; }
        public virtual ICollection<UposlenikRola> UposlenikRolas { get; set; }

        public string FullName
        {
            get { return Ime + " " + Prezime; }
        }

    }
}
