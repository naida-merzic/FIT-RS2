using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{

    public class UposlenikController : BaseCRUDController<Model.Uposlenik, UposlenikSearchObject, KorisnickiRacunInsertRequest, KorisnickiRacunInsertRequest>
    {
        public UposlenikController(IUposlenikService service)
            : base(service)
        {
        }
        //[Authorize("Admin")]
        public override Uposlenik Insert([FromBody] KorisnickiRacunInsertRequest insert)
        {
            return base.Insert(insert);
        }
        //[Authorize("Admin")]
        public override Uposlenik Update(int id, [FromBody] KorisnickiRacunInsertRequest update)
        {
            return base.Update(id, update);
        }
    }
}
