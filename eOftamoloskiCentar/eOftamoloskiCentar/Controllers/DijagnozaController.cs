using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class DijagnozaController : BaseCRUDController<Model.Dijagnoza, DijagnozaSearchObject, DijagnozaUpsertRequest, DijagnozaUpsertRequest>
    {
        public DijagnozaController(IDijagnozaService service)
            : base(service)
        {
        }
    }
}
