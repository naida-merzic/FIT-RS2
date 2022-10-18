using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class RolaController : BaseController<Model.Rola, BaseSearchObject>
    {
        public RolaController(IService<Model.Rola, BaseSearchObject> service)
            : base(service)
        {
        }
    }
}
