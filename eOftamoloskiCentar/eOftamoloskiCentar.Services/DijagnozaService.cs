using AutoMapper;
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
    public class DijagnozaService : BaseCRUDService<Model.Dijagnoza, Database.Dijagnoza, DijagnozaSearchObject, DijagnozaUpsertRequest, DijagnozaUpsertRequest>, IDijagnozaService
    {
        public DijagnozaService(OftamoloskiCentarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        public override IQueryable<Database.Dijagnoza> AddFilter(IQueryable<Database.Dijagnoza> query, DijagnozaSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv == search.Naziv);
            }
            return filteredQuery;
        }
    }
}
