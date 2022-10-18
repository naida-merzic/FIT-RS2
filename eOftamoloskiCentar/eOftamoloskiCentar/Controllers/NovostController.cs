using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class NovostController : BaseCRUDController<Model.Novost, NovostSearchObject, NovostUpsertRequest, NovostUpsertRequest>
    {
        public NovostController(INovostService service)
            : base(service)
        {
        }
    }
}
