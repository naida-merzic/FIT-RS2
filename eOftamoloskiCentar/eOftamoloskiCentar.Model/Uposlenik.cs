using System;
using System.Collections.Generic;
using System.Linq;


namespace eOftamoloskiCentar.Model
{
    public partial class Uposlenik
    {
        public int UposlenikId { get; set; }
        public int? SpolId { get; set; }
        public bool? Status { get; set; }
        public int? KorisnickiRacunId { get; set; }
        //public string RoleNames => string.Join(", ", UposlenikRolas?.Select(x => x.Rola?.Naziv)?.ToList());
        public string RoleNames { get; set; }
        //public virtual Osoba? Osoba { get; set; }
        //public virtual ICollection<DijagnozaUposlenik> DijagnozaUposleniks { get; set; }
        // public virtual ICollection<Novost> Novosts { get; set; }
        public virtual ICollection<UposlenikRola> UposlenikRolas { get; set; }
        public virtual Model.KorisnickiRacun KorisnickiRacun { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string KorisnickoIme { get; set; }
        public string DatumRodjenja { get; set; }

        public string FullName
        {
            get { return Ime + " " + Prezime; }
        }

    }
}
