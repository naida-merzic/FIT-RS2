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
        [Authorize(Roles = "Admin, BasicUser")]

        public override Novost Insert([FromBody] NovostUpsertRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Admin, BasicUser")]

        public override Novost Update(int id, [FromBody] NovostUpsertRequest update)
        {
            return base.Update(id, update);
        }
        [Authorize(Roles = "Admin,BasicUser")]

        public override Novost Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
