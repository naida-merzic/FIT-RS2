using AutoMapper;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class BaseService<T, TDb, TSearch> : IService<T, TSearch> where T : class where TDb : class where TSearch : BaseSearchObject
    {
        public OftamoloskiCentarContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public BaseService(OftamoloskiCentarContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        

        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var entity = Context.Set<TDb>().AsQueryable();

            entity = AddFilter(entity, search);

            if(search?.Page.HasValue ==true && search?.PageSize.HasValue == true)
            {
                entity = entity.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = entity.ToList();

            return Mapper.Map<IList<T>>(list);
        }
        

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }
        public virtual T GetById(int Id)
        {
            var entity = Context.Set<TDb>().Find(Id);

            return Mapper.Map<T>(entity);
        }
    }
}
