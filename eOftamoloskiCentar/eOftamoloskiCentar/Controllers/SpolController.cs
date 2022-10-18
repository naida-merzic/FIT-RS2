using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class SpolController : BaseCRUDController<Model.Spol, SpolSearchObject, SpolUpsertRequest, SpolUpsertRequest>
    {
        public ISpolService SpolService { get; set; }
        public SpolController(ISpolService service)
            : base(service)
        {
            SpolService = service;
        }
    }
}
