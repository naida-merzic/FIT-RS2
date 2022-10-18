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
    public interface IArtikliService : ICRUDService<Artikal, ArtikalSearchObject, ArtikalInsertRequest, ArtikalUpdateRequest>
    {
        Model.Artikal Activate(int id);
        List<string> AllowedActions(int id);
        List<Model.Artikal> Recommend(int id);
    }
}
