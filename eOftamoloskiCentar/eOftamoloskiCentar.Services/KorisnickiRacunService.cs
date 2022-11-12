using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Helper;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class KorisnickiRacunService : IKorisnickiRacun
    {
        private readonly OftamoloskiCentarContext _context;
        private readonly IMapper _mapper;

        public KorisnickiRacunService(OftamoloskiCentarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthKorisnickiRacun Login(AuthenticationRequest request)
        {
            var user = _context.KorisnickiRacuns.Include("Uposleniks.UposlenikRolas.Rola").Include("Klijents").FirstOrDefault(x => x.KorisnickoIme == request.KorisnickoIme);
            
            if (user == null)
            {
                throw new UserException("Pogrešno korisničko ime ili lozinka");
            }

            var newHash = HashGenerator.GenerateHash(user.LozinkaSalt, request.Lozinka);

            if (newHash != user.LozinkaHash)
            {
                throw new UserException("Pogrešno korisničko ime ili lozinka");

            }

            return _mapper.Map<AuthKorisnickiRacun>(user);
        }
    }
}
