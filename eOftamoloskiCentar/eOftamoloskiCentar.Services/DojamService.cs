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
    public class DojamService : BaseCRUDService<Model.Dojam, Database.Dojam, Model.SearchObjects.DojamSearchObject, Model.Dojam, Model.Dojam>, IDojamService
    {
        public DojamService(OftamoloskiCentarContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Dojam> AddFilter(IQueryable<Database.Dojam> query, DojamSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search.KlijentId != null && search.KlijentId != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.KlijentId == search.KlijentId);
            }

            if (search.KlijentId != null && search.ArtikalId != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.ArtikalId == search.ArtikalId);
            }
            if (search.KlijentId != null && search.IsLiked != null)
            {
                filteredQuery = filteredQuery.Where(x => x.IsLiked == search.IsLiked);
            }

            return filteredQuery;
        }
    }
}
