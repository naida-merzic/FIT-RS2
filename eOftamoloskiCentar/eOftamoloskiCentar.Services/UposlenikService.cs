using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Helper;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class UposlenikService : BaseCRUDService<Model.Uposlenik, Database.Uposlenik, UposlenikSearchObject, KorisnickiRacunInsertRequest, KorisnickiRacunInsertRequest>, IUposlenikService
    {
        public UposlenikService(OftamoloskiCentarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        public override Model.Uposlenik Insert(KorisnickiRacunInsertRequest insert)
        {
            var salt = HashGenerator.GenerateSalt();
            var hash = HashGenerator.GenerateHash(salt, insert.Lozinka);

            if (insert.Lozinka != insert.LozinkaPotvrda)
            {
                throw new UserException("Password and confirmation must be the same");
            }

            var racun = Mapper.Map<Database.KorisnickiRacun>(insert);

            racun.LozinkaSalt = salt;
            racun.LozinkaHash = hash;

            Context.KorisnickiRacuns.Add(racun);
            Context.SaveChanges();

            var uposlenikNew = new UposlenikInsertRequest()
            {
                SpolId = insert.SpolId,
                KorisnickiRacunId = racun.KorisnickiRacunId
            };
            var uposlenik = Mapper.Map<Database.Uposlenik>(uposlenikNew);

            Context.Uposleniks.Add(uposlenik);
            Context.SaveChanges();

            foreach (var rolaId in insert.RoleList)
            {
                Database.UposlenikRola uposleniciRola = new Database.UposlenikRola();
                uposleniciRola.RolaId = rolaId;
                uposleniciRola.UposlenikId = uposlenik.UposlenikId;
                uposleniciRola.DatumIzmjene = DateTime.Now;

                Context.UposlenikRolas.Add(uposleniciRola);
            }
            Context.SaveChanges();


            return Mapper.Map<Model.Uposlenik>(uposlenik);

        }

        public override Model.Uposlenik Update(int id, KorisnickiRacunInsertRequest update)
        {
            var entity2 = Context.Uposleniks.Find(id);

            var korRacId = entity2.KorisnickiRacunId;
            var entity = Context.KorisnickiRacuns.Find(korRacId);
            var racun = Mapper.Map<Database.KorisnickiRacun>(update);

            if (entity != null)
            {
                Mapper.Map(update, entity);
                Context.SaveChanges();
            }
            var UposlenikNew = new UposlenikInsertRequest()
            {
                SpolId = update.SpolId,
                KorisnickiRacunId = racun.KorisnickiRacunId,
                RoleList = update.RoleList,
            };
            //var uposlenik = Mapper.Map<Database.Uposlenik>(UposlenikNew);
            //Mapper.Map(UposlenikNew, uposlenik);

            //Context.SaveChanges();
            return Mapper.Map<Model.Uposlenik>(UposlenikNew);
        }
        public override Model.Uposlenik Delete(int id)
        {
            foreach (var item in Context.UposlenikRolas)
            {
                if (id == item.UposlenikId)
                {
                    Context.UposlenikRolas.Remove(item);
                }
            }
            foreach (var item in Context.Novosts)
            {
                if (id == item.UposlenikId)
                {
                    Context.Novosts.Remove(item);
                }
            }
            var entity = Context.Uposleniks.Find(id);
            var korRacId = entity.KorisnickiRacunId;
            var entity2 = Context.KorisnickiRacuns.Find(korRacId);
            if (entity2 != null)
            {
                Context.KorisnickiRacuns.Remove(entity2);
                Context.SaveChanges();
            }
            if (entity != null)
            {
                Context.Uposleniks.Remove(entity);
                Context.SaveChanges();
            }
            var returnObj = new Model.Uposlenik()
            {
                SpolId = (int)entity.SpolId,
                UposlenikId = entity.UposlenikId
            };

            return Mapper.Map<Model.Uposlenik>(returnObj);
        }

        //public override void BeforeInsert(UposlenikInsertRequest insert, Database.Uposlenik entity)
        //{
        //    var salt = GenerateSalt();
        //    entity.LozinkaSalt = salt;
        //    entity.LozinkaHash = GenerateHash(salt, insert.Lozinka);
        //    base.BeforeInsert(insert, entity);
        //}

        public static string GenerateSalt()
        {
            //RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            //var byteArray = new byte[16];
            //provider.GetBytes(byteArray);


            return Convert.ToBase64String(new byte[16]);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public override IQueryable<Database.Uposlenik> AddFilter(IQueryable<Database.Uposlenik> query, UposlenikSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickiRacun.Ime.Contains(search.Ime));
            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickiRacun.Prezime.Contains(search.Prezime)
                    || x.KorisnickiRacun.Ime.Contains(search.Prezime)
                    || x.KorisnickiRacun.Prezime.Contains(search.Prezime));
            }

            return filteredQuery;
        }
        public override IQueryable<Database.Uposlenik> AddInclude(IQueryable<Database.Uposlenik> query, UposlenikSearchObject search = null)
        {
            if (search?.IncludeRoles == true)
            {
                query = query.Include("UposlenikRolas.Rola").Include(x=>x.KorisnickiRacun);
            }
            return query;
        }
        //public Model.Uposlenik Login(string username, string password)
        //{
        //    var entity = Context.Uposleniks.Include("UposlenikRolas.Rola").FirstOrDefault(x => x.KorisnickoIme == username);
        //    if (entity == null)
        //    {
        //        return null;
        //    }

        //    var hash = GenerateHash(entity.LozinkaSalt, password);

        //    if (hash != entity.LozinkaHash)
        //    {
        //        return null;
        //    }

        //    return Mapper.Map<Model.Uposlenik>(entity);
        //}
    }
}
