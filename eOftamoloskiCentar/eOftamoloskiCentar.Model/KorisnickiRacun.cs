using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model
{
    public class KorisnickiRacun
    {
        public int KorisnickiRacunId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        //public bool? Status { get; set; }


        [JsonIgnore]
        public string ImePrezime
        {
            get { return Ime + " " + Prezime; }
        }
    }
}
