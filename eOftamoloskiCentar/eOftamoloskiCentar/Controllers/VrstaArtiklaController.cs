using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Mvc;
using eOftamoloskiCentar.Model;

namespace eOftamoloskiCentar.Controllers
{
    public class VrstaArtiklaController : BaseCRUDController<Model.VrstaArtikla, VrstaArtiklaSearchObject, VrstaArtiklaUpsertRequest, VrstaArtiklaUpsertRequest>
    {
        public VrstaArtiklaController(IVrstaArtiklaService service)
            : base(service)
        {
        }
    }
}
