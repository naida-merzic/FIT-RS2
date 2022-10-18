using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class NovostService : BaseCRUDService<Model.Novost, Database.Novost, NovostSearchObject, NovostUpsertRequest, NovostUpsertRequest>, INovostService
    {
        public NovostService(OftamoloskiCentarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        public override Model.Novost Delete(int id)
        {
            var entity = Context.Novosts.Find(id);
            if (entity == null)
                throw new ArgumentNullException();
            var x = entity;
            Context.Novosts.Remove(entity);
            Context.SaveChanges();
            return Mapper.Map<Model.Novost>(x);
        }

        public override IQueryable<Database.Novost> AddFilter(IQueryable<Database.Novost> query, NovostSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Naslov))
            {
                filteredQuery = filteredQuery.Where(x => x.Naslov.StartsWith(search.Naslov));
            }
            return filteredQuery;
        }
        public override IQueryable<Database.Novost> AddInclude(IQueryable<Database.Novost> query, NovostSearchObject search = null)
        {
            //if (search?.IncludeRoles == true)
            //{
            query = query.Include(x => x.Uposlenik).AsQueryable();
            //}
            return query;
        }
    }
}
