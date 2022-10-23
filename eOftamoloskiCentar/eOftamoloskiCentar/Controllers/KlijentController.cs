using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    [Authorize]
    public class KlijentController : BaseCRUDController<Model.Klijent, KlijentSearchObject, KlijentInsertRequest, KlijentUpdateRequest>
    {
        private readonly IKlijentService service;
        public KlijentController(IKlijentService service)
            : base(service)
        {
            this.service = service;
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
        //[Authorize(Roles = "Klijent")]
        [Consumes("application/json")]
        [HttpPost("Login")]
        public Klijent Login([FromBody] AuthenticationRequest request)
        {
            return  service.Login(request);
        }
    }
}
