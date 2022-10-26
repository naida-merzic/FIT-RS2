using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class UposlenikInsertRequest
    {
        public int? SpolId { get; set; }
        public int? KorisnickiRacunId { get; set; }
        public List<int> RoleList { get; set; } = new List<int> { };

    }
}
