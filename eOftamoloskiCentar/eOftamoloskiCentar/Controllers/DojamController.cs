﻿using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class DojamController : BaseCRUDController<Model.Dojam, Model.SearchObjects.DojamSearchObject, Model.Dojam, Model.Dojam>
    {
        private readonly IDojamService service;

        public DojamController(IDojamService service) : base(service)
        {
            this.service = service;
        }
    }
}
