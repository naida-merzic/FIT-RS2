using Microsoft.AspNetCore.Mvc;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;

namespace eOftamoloskiCentar.Controllers
{
    public class RacunController : BaseCRUDController<Model.Racun, BaseSearchObject, RacunInsertRequest, RacunUpdateRequest>
    {
        public RacunController(IRacunService service)
            : base(service)
        {
        }
    }
}
