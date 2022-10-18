using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Model
{
    public partial class Klijent
    {
        public int KlijentId { get; set; }
        public int? SpolId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Spol Spol { get; set; }
        public string Naziv { get; set; }


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
