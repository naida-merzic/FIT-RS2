using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class RacunInsertRequest
    {
        public List<StavkaRacunInsertRequest> Items { get; set; } = new List<StavkaRacunInsertRequest>();
    }
}
