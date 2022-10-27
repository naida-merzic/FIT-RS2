using AutoMapper;
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
    public class RacunService : BaseCRUDService<Model.Racun, Database.Racun, BaseSearchObject, RacunInsertRequest, RacunUpdateRequest>, IRacunService
    {
        public RacunService(OftamoloskiCentarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        public override async void BeforeInsert(RacunInsertRequest insert, Racun entity)
        {
            decimal _iznos = 0;
            foreach (var item in insert.Items)
            {
                var _artikal = Context.Artikals.Where(x => x.ArtikalId == item.ArtikalId).FirstOrDefault();
                var x = _artikal.Cijena * item.Kolicina;
                decimal y = (decimal)x;
                _iznos += y;
            }
            entity.KlijentId = insert.KlijentId; //todo get from session
            entity.Datum = DateTime.Now;
            entity.BrojRacuna = (Context.Racuns.Count() + 1);
            entity.Iznos = _iznos;
            base.BeforeInsert(insert, entity);
        }

        public override Model.Racun Insert(RacunInsertRequest insert)
        {
            var result = base.Insert(insert);
            foreach (var item in insert.Items)
            {
                //call context to store items
                Database.StavkaRacuna dbItem = new StavkaRacuna();
                dbItem.RacunId = result.RacunId;
                dbItem.ArtikalId = item.ArtikalId;
                dbItem.Kolicina = item.Kolicina;

                Context.StavkaRacunas.Add(dbItem);
            }

            Context.SaveChanges();
            return result;
        }
        public override Model.Racun Delete(int id)
        {
            foreach (var item in Context.StavkaRacunas)
            {
                if (id == item.RacunId)
                {
                    Context.StavkaRacunas.Remove(item);
                }
            }
            var entity = Context.Racuns.Find(id);
            if (entity == null)
                throw new ArgumentNullException();
            var x = entity;
            Context.Racuns.Remove(entity);
            Context.SaveChanges();
            return Mapper.Map<Model.Racun>(x);
        }
        public override IQueryable<Database.Racun> AddInclude(IQueryable<Database.Racun> query, BaseSearchObject search = null)
        {
            query = query.Include(x => x.Klijent).AsQueryable();

            return query;
        }
    }
}
