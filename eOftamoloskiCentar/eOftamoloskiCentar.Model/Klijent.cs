using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Model
{
    public partial class Klijent
    {
        public int KlijentId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string SlikaPutanja { get; set; }
        public byte[] Slika { get; set; }
        public bool? Status { get; set; }
        public int GradId { get; set; }
        public int SpolId { get; set; }
        public Spol Spol { get; set; }
        public string Naziv { get; set; }


        public virtual Model.KorisnickiRacun KorisnickiRacun { get; set; }


        public string FullName
        {
            get { return Ime + " " + Prezime; }
        }
        public override string ToString()
        {
            return FullName;
        }
    }
}
