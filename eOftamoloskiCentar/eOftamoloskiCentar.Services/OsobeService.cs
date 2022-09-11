using AutoMapper;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eOftamoloskiCentar.Services.Database;

namespace eOftamoloskiCentar.Services
{
    public class OsobeService : BaseCRUDService<Model.Osoba, Database.Osoba, OsobaSearchObject, OsobaUpsertRequest, OsobaUpsertRequest>, IOsobeService
    {
        public OsobeService(OftamoloskiCentarContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
        public override IQueryable<Database.Osoba> AddFilter(IQueryable<Database.Osoba> query, OsobaSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrEmpty(search?.Ime))
            {
                filteredQuery = filteredQuery.Where(x => x.Ime == search.Ime);
            }
            if (search?.OsobaId.HasValue == true)
            {
                filteredQuery = filteredQuery.Where(x => x.OsobaId == search.OsobaId);
            }
           
            return filteredQuery;
        }
    }
}
