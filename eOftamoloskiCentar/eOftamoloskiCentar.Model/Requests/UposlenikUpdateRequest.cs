﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class UposlenikUpdateRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string PasswordPotvrda { get; set; }
        public List<int> RoleList { get; set; } = new List<int> { };
    }
}
