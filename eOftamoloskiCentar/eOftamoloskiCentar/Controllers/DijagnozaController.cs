using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class DijagnozaController : BaseCRUDController<Model.Dijagnoza, DijagnozaSearchObject, DijagnozaUpsertRequest, DijagnozaUpsertRequest>
    {
        public DijagnozaController(IDijagnozaService service)
            : base(service)
        {
        }
        [Authorize(Roles = "Admin, BasicUser")]

        public override Dijagnoza Insert([FromBody] DijagnozaUpsertRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Admin, BasicUser")]

        public override Dijagnoza Update(int id, [FromBody] DijagnozaUpsertRequest update)
        {
            return base.Update(id, update);
        }
        [Authorize(Roles = "Admin,BasicUser")]

        public override Dijagnoza Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
