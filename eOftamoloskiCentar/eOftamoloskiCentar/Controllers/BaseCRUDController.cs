﻿using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch
         : class where TInsert : class where TUpdate : class
    {
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
        }

        [HttpPost]
        public virtual T Insert([FromBody] TInsert insert)
        {
            var result = ((ICRUDService<T, TSearch, TInsert, TUpdate>)this._service).Insert(insert);

            return result;
        }

        [HttpPut("{id}")]
        public virtual T Update(int id, [FromBody] TUpdate update)
        {
            var result = ((ICRUDService<T, TSearch, TInsert, TUpdate>)this._service).Update(id, update);

            return result;
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public virtual T Delete(int id)
        {
            var result = ((ICRUDService<T, TSearch, TInsert, TUpdate>)this._service).Delete(id);

            return result;
        }

    }
}
