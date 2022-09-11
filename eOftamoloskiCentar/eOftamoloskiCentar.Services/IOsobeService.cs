using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public interface IOsobeService : ICRUDService<Osoba, OsobaSearchObject, OsobaUpsertRequest, OsobaUpsertRequest>
    {
    }
}
