using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class KlijentInsertRequest
    {
        public int? SpolId { get; set; }
        public int? KorisnickiRacunId { get; set; }
    }
}
