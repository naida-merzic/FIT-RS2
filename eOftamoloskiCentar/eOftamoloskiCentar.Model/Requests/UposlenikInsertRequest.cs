using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class UposlenikInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }
        public string Lozinka { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]

        public string KorisnickoIme { get; set; }
        [Required(AllowEmptyStrings = false)]

        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public bool Status { get; set; }
        public string LozinkaPotvrda { get; set; }
        public List<int> RoleList { get; set; } = new List<int> { };

    }
}
