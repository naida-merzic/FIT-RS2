using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class KlijentController : BaseCRUDController<Model.Klijent, KlijentSearchObject, Model.Requests.KorisnickiRacunInsertRequest, KorisnickiRacunInsertRequest>
    {
        private readonly IKlijentService service;
        public KlijentController(IKlijentService service)
            : base(service)
        {
            this.service = service;
        }
        [Authorize(Roles = "Admin,BasicUser")]

        public override Klijent Insert([FromBody] KorisnickiRacunInsertRequest insert)
        {
            return base.Insert(insert);
        }
        [Authorize(Roles = "Admin,BasicUser")]

        public override Klijent Update(int id, [FromBody] KorisnickiRacunInsertRequest update)
        {
            return base.Update(id, update);
        }
        //[Authorize(Roles = "Klijent")]
        //[Consumes("application/json")]
        //[HttpPost("Login")]
        //public Klijent Login([FromBody] AuthenticationRequest request)
        //{
        //    return  service.Login(request);
        //}
    }
}
