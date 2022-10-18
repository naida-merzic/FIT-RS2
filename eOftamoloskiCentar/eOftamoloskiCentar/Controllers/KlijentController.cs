using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class KlijentController : BaseCRUDController<Model.Klijent, KlijentSearchObject, KlijentInsertRequest, KlijentUpdateRequest>
    {
        public KlijentController(IKlijentService service)
            : base(service)
        {
        }
        //[Authorize("Admin")]
        public override Klijent Insert([FromBody] KlijentInsertRequest insert)
        {
            return base.Insert(insert);
        }
        //[Authorize("Admin")]
        public override Klijent Update(int id, [FromBody] KlijentUpdateRequest update)
        {
            return base.Update(id, update);
        }
    }
}
