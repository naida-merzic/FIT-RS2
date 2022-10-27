using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.ArtikalStateMachine;
using eOftamoloskiCentar.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class TerminService : BaseCRUDService<Model.Termin, Database.Termin, TerminSearchObject, TerminInsertRequest, TerminUpdateRequest>, ITerminService
    {
        public TerminService(OftamoloskiCentarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        public override Model.Termin Insert(TerminInsertRequest insert)
        {

            var entity = base.Insert(insert);


            //treba biti insert uposlenika 

            return entity;
        }
        public override Model.Termin Delete(int id)
        {
            
            var entity = Context.Termins.Find(id);
            if (entity == null)
                throw new ArgumentNullException();
            var x = entity;
            Context.Termins.Remove(entity);
            Context.SaveChanges();
            return Mapper.Map<Model.Termin>(x);
        }

        public override IQueryable<Database.Termin> AddFilter(IQueryable<Database.Termin> query, TerminSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.VrstaPregleda))
            {
                filteredQuery = filteredQuery.Where(x => x.VrstaPregleda == search.VrstaPregleda);
            }

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                filteredQuery = filteredQuery.Where(x => x.Klijent.KorisnickiRacun.Ime.Contains(search.Ime)
                    || x.Klijent.KorisnickiRacun.Prezime.Contains(search.Ime));
            }

            if (search?.KlijentId != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.Klijent.KlijentId == search.KlijentId);
            }

            return filteredQuery;
        }
        public override IQueryable<Database.Termin> AddInclude(IQueryable<Database.Termin> query, TerminSearchObject search = null)
        {
            query = query.Include(x => x.Klijent).ThenInclude(x=>x.KorisnickiRacun).AsQueryable();

            return query;
        }

    }
}
