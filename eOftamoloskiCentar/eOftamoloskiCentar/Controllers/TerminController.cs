﻿using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    [Authorize]

    public class TerminController : BaseCRUDController<Model.Termin, TerminSearchObject, TerminInsertRequest, TerminUpdateRequest>
    {
        public TerminController(ITerminService service)
            : base(service)
        {
        }
        public override Termin Insert([FromBody] TerminInsertRequest insert)
        {
            return base.Insert(insert);
        }

        public override Termin Update(int id, [FromBody] TerminUpdateRequest update)
        {
            return base.Update(id, update);
        }
    }
}
