﻿using Microsoft.AspNetCore.Mvc;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;

namespace eOftamoloskiCentar.Controllers
{
    [Authorize]

    public class RacunController : BaseCRUDController<Model.Racun, BaseSearchObject, RacunInsertRequest, RacunUpdateRequest>
    {
        public RacunController(IRacunService service)
            : base(service)
        {
        }

        public override Racun Insert([FromBody] RacunInsertRequest insert)
        {
            return base.Insert(insert);
        }
    }
}
