using System;
using System.Collections.Generic;
using System.Text;

namespace eOftamoloskiCentar.Model.SearchObjects
{
    public class DojamSearchObject:BaseSearchObject
    {
        public bool? IsLiked { get; set; }
        public int? ArtikalId { get; set; }
        public int? KlijentId { get; set; }
    }
}
