using AutoMapper;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class UposlenikService : BaseCRUDService<Model.Uposlenik, Database.Uposlenik, UposlenikSearchObject, UposlenikInsertRequest, UposlenikUpdateRequest>, IUposlenikService
    {
        public UposlenikService(OftamoloskiCentarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        public override Model.Uposlenik Insert(UposlenikInsertRequest insert)
        {
            var entity = base.Insert(insert);


            foreach (var rolaId in insert.RoleList)
            {
                Database.UposlenikRola uposleniciRola = new Database.UposlenikRola();
                uposleniciRola.RolaId = rolaId;
                uposleniciRola.UposlenikId = entity.UposlenikId;
                uposleniciRola.DatumIzmjene = DateTime.Now;

                Context.UposlenikRolas.Add(uposleniciRola);
            }

            Context.SaveChanges();

            return entity;
        }

        public override void BeforeInsert(UposlenikInsertRequest insert, Database.Uposlenik entity)
        {
            var salt = GenerateSalt();
            entity.LozinkaSalt = salt;
            entity.LozinkaHash = GenerateHash(salt, insert.Password);
            base.BeforeInsert(insert, entity);
        }

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
    }
}
