using System;

namespace eOftamoloskiCentar.Model
{
    public partial class Osoba
    {
        public int OsobaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public int? SpolId { get; set; }

       // public virtual Spol? Spol { get; set; }
       // public virtual ICollection<Klijent> Klijents { get; set; }
       // public virtual ICollection<Uposlenik> Uposleniks { get; set; }
    }
}
