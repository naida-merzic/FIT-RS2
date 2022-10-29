using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Helper;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.ArtikalStateMachine;
using eOftamoloskiCentar.Services.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class KlijentService : BaseCRUDService<Model.Klijent, Database.Klijent, KlijentSearchObject, KorisnickiRacunInsertRequest, KorisnickiRacunInsertRequest>, IKlijentService
    {
        public KlijentService(OftamoloskiCentarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        [HttpPost]
        public override Model.Klijent Insert([FromBody] KorisnickiRacunInsertRequest insert)
        {

            var salt = HashGenerator.GenerateSalt();
            var hash = HashGenerator.GenerateHash(salt, insert.Lozinka);

            var racun = Mapper.Map<Database.KorisnickiRacun>(insert);

            racun.LozinkaSalt = salt;
            racun.LozinkaHash = hash;

            Context.KorisnickiRacuns.Add(racun);
            Context.SaveChanges();

            var klijentNew = new KlijentInsertRequest()
            {
                SpolId = insert.SpolId,
                KorisnickiRacunId = racun.KorisnickiRacunId
            };
            var klijent = Mapper.Map<Database.Klijent>(klijentNew);

            Context.Klijents.Add(klijent);
            Context.SaveChanges();


            return Mapper.Map<Model.Klijent>(klijent);
        }
        public override Model.Klijent Update(int id, KorisnickiRacunInsertRequest update)
        {
            var entity2 = Context.Klijents.Find(id);

            var korRacId = entity2.KorisnickiRacunId;
            var entity = Context.KorisnickiRacuns.Find(korRacId);
            var racun = Mapper.Map<Database.KorisnickiRacun>(update);

            if (entity != null)
            {
                Mapper.Map(update, entity);
                Context.SaveChanges();
            }
            var klijentNew = new KlijentInsertRequest()
            {
                SpolId = update.SpolId,
                KorisnickiRacunId = racun.KorisnickiRacunId
            };
            var klijent = Mapper.Map<Database.Klijent>(klijentNew);
            Mapper.Map(klijentNew, klijent);

            Context.SaveChanges();
            return Mapper.Map<Model.Klijent>(klijentNew);
        }
        public override Model.Klijent Delete(int id)
        {
            foreach (var item in Context.Termins)
            {
                if (id == item.KlijentId)
                {
                    Context.Termins.Remove(item);
                }
            }

            var temp = Context.Racuns.Include(x => x.StavkaRacunas);


            foreach (var item in temp)
            {
                if (id == item.KlijentId)
                {
                    foreach (var itemS in item.StavkaRacunas)
                    {
                        if (item.RacunId == itemS.RacunId)
                        {
                            Context.StavkaRacunas.Remove(itemS);
                        }
                    }
                    //Context.SaveChanges();
                    Context.Racuns.Remove(item);
                }
            }

            var entity2 = Context.Klijents.Find(id);

            var korRacId = entity2.KorisnickiRacunId;
            var entity = Context.KorisnickiRacuns.Find(korRacId);
            if (entity != null)
            {
                Context.KorisnickiRacuns.Remove(entity);
                Context.SaveChanges();
            }

            if (entity2 != null)
            {
                Context.Klijents.Remove(entity2);
                Context.SaveChanges();
            }

            var returnObj = new Model.Klijent()
            {
                SpolId = (int)entity2.SpolId,
                KlijentId = entity2.KlijentId
            };
            return Mapper.Map<Model.Klijent>(returnObj);
        }

        public override IQueryable<Database.Klijent> AddFilter(IQueryable<Database.Klijent> query, KlijentSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickiRacun.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickiRacun.Prezime.Contains(search.Prezime)
                    || x.KorisnickiRacun.Prezime.Contains(search.Prezime)
                    || x.KorisnickiRacun.Prezime.Contains(search.Prezime));
            }

            return filteredQuery;
        }
        public override IQueryable<Database.Klijent> AddInclude(IQueryable<Database.Klijent> query, KlijentSearchObject search = null)
        {
            //if (search?.IncludeRoles == true)
            //{
            //    query = query.Include("UposlenikRolas.Rola");
            //}
            query = query.Include(x => x.Spol).Include(x => x.KorisnickiRacun).AsQueryable();

            return query;
        }
        ////[HttpPost]
        //public Model.Klijent Login(/*[FromBody]*/ AuthenticationRequest request)
        //{
        //    var user =  Context.Klijents.Include("KorisnickiRacun").FirstOrDefault(s => s.KorisnickiRacun.KorisnickoIme == request.KorisnickoIme);

        //    if (user == null)
        //    {
        //        throw new UnauthorizedAccessException("Pogrešno korisničko ime ili lozinka");
        //    }

        //    /*if (user.KorisnickiRacun.Status == false)
        //    {
        //        throw new UserException("Korisnički račun je deaktiviran.");

        //    }*/

        //    var newHash = HashGenerator.GenerateHash(user.KorisnickiRacun.LozinkaSalt, request.Lozinka);

        //    if (newHash != user.KorisnickiRacun.LozinkaHash)
        //    {
        //        throw new UnauthorizedAccessException("Pogrešno korisničko ime ili lozinka");

        //    }

        //    var result = Mapper.Map<Model.Klijent>(user);

        //    /*var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiRacun", $"{result.SlikaPutanja}");
        //    result.Slika =  imageHelper.FindImage(directory);*/

        //    return result;
        //}

    }
}
