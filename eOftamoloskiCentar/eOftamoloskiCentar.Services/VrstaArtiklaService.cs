using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class VrstaArtiklaService : BaseCRUDService<Model.VrstaArtikla, Database.VrstaArtikla, VrstaArtiklaSearchObject, VrstaArtiklaUpsertRequest, VrstaArtiklaUpsertRequest>, IVrstaArtiklaService
    {
        public VrstaArtiklaService(OftamoloskiCentarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        public override IQueryable<Database.VrstaArtikla> AddFilter(IQueryable<Database.VrstaArtikla> query, VrstaArtiklaSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NazivArtikla))
            {
                filteredQuery = filteredQuery.Where(x => x.NazivArtikla.StartsWith(search.NazivArtikla));
            }
            return filteredQuery;
        }
    }
}
