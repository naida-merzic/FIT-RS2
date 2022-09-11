using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class OsobaController : BaseCRUDController<Model.Osoba, OsobaSearchObject, OsobaUpsertRequest, OsobaUpsertRequest>
    {
        public OsobaController(IOsobeService service)
            : base(service)
        {
        }
    }
}
