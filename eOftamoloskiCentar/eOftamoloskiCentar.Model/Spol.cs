using System;
using System.Collections.Generic;

namespace eOftamoloskiCentar.Model
{
    public partial class Spol
    {
        public int SpolId { get; set; }
        public string Naziv { get; set; }

        //public virtual ICollection<Klijent> Klijents { get; set; }
        //public virtual ICollection<Uposlenik> Uposleniks { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
