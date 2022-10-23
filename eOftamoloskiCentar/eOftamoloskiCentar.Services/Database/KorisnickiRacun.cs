using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class KorisnickiRacun
    {
        public KorisnickiRacun()
        {
            Klijents = new HashSet<Klijent>();
            Uposleniks = new HashSet<Uposlenik>();
        }

        public int KorisnickiRacunId { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Email { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string? KorisnickoIme { get; set; }
        public string? LozinkaHash { get; set; }
        public string? LozinkaSalt { get; set; }

        public virtual ICollection<Klijent> Klijents { get; set; }
        public virtual ICollection<Uposlenik> Uposleniks { get; set; }
    }
}
