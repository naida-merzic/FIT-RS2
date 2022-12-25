using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Mvc;
using eOftamoloskiCentar.Model;
using Microsoft.AspNetCore.Authorization;

namespace eOftamoloskiCentar.Controllers
{
    public class VrstaArtiklaController : BaseCRUDController<Model.VrstaArtikla, VrstaArtiklaSearchObject, VrstaArtiklaUpsertRequest, VrstaArtiklaUpsertRequest>
    {
        public VrstaArtiklaController(IVrstaArtiklaService service)
            : base(service)
        {
        }
        public override VrstaArtikla Insert([FromBody] VrstaArtiklaUpsertRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Admin, BasicUser")]

        public override VrstaArtikla Update(int id, [FromBody] VrstaArtiklaUpsertRequest update)
        {
            return base.Update(id, update);
        }
        [Authorize(Roles = "Admin,BasicUser")]

        public override VrstaArtikla Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
