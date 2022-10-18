using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.Requests
{
    public class NovostUpsertRequest
    {
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime? DatumObjave { get; set; }
        public int? UposlenikId { get; set; }
    }
}
