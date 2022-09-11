﻿using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class UposlenikController : BaseCRUDController <Model.Uposlenik, UposlenikSearchObject, UposlenikInsertRequest, UposlenikUpdateRequest>
    {
        public UposlenikController(IUposlenikService service)
            : base(service)
        {
        }
        public override Uposlenik Insert([FromBody] UposlenikInsertRequest insert)
        {
            return base.Insert(insert);
        }

        public override Uposlenik Update(int id, [FromBody] UposlenikUpdateRequest update)
        {
            return base.Update(id, update);
        }
    }
}
