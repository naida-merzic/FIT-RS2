﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class KorisnickiRacunInsertRequest
    {
        //[Required]
        //[RegularExpression(@"^\p{Lu}{1}[\p{Ll}\s\d]{2,29}$", ErrorMessage = "Neispravan format. Prvo slovo mora biti veliko, minimalno 3 i maximalno 20 karaktera.")]
        public string Ime { get; set; }
        //[Required]
        //[RegularExpression(@"^\p{Lu}{1}[\p{Ll}\s\d]{2,29}$", ErrorMessage = "Neispravan format. Prvo slovo mora biti veliko, minimalno 3 i maximalno 20 karaktera.")]
        public string Prezime { get; set; }
        //[Required]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Neispravan format emaila.")]
        public string Email { get; set; }
        //[Required]
        //[RegularExpression(@"^([0-9]){3}(-|/|\s)?([0-9]){3}(-|/|\s)?([0-9]){3,4}$", ErrorMessage = "Neispravan format. Primjer: 060-000-000 ili 060/000/0000 ili 0621234567")]
        public string BrojTelefona { get; set; }
        //[Required]
        public DateTime DatumRodjenja { get; set; }
        public int? SpolId { get; set; }

        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Lozinka { get; set; }
        [Required]
        public string LozinkaPotvrda { get; set; }
        //[Required]
        //public int GradId { get; set; }
        [Required]
        public string Adresa { get; set; }
        public bool? Status { get; set; }
        //public byte[] Slika { get; set; }
        public List<int> RoleList { get; set; } = new List<int> { };

    }
}
