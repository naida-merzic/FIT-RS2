using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Artikal, Model.Artikal>();
            CreateMap<Database.Dijagnoza, Model.Dijagnoza>();
            CreateMap<Database.VrstaArtikla, Model.VrstaArtikla>();
            CreateMap<Database.Uposlenik, Model.Uposlenik>();
            CreateMap<Database.Uposlenik, Model.Uposlenik>();
            CreateMap<Database.Rola, Model.Rola>();
            CreateMap<Database.UposlenikRola, Model.UposlenikRola>();
            CreateMap<Database.Klijent, Model.Klijent>();
            CreateMap<Database.Spol, Model.Spol>();
            CreateMap<Database.Termin, Model.Termin>()
                .ForMember(y => y.FullName, x => x.MapFrom(v => v.Klijent.KorisnickiRacun.Ime + " " + v.Klijent.KorisnickiRacun.Prezime)).ReverseMap();
            CreateMap<Database.Novost, Model.Novost>();
            CreateMap<Database.Racun, Model.Racun>();
            CreateMap<Database.StavkaRacuna, Model.StavkaRacuna>();
            CreateMap<Database.KorisnickiRacun, Model.KorisnickiRacun>();
            CreateMap<Database.KorisnickiRacun, Model.AuthKorisnickiRacun>().ReverseMap();
            CreateMap<Database.Dojam, Model.Dojam>().ReverseMap();



            CreateMap<ArtikalInsertRequest, Database.Artikal>();
            CreateMap<ArtikalUpdateRequest, Database.Artikal>();
            CreateMap<DijagnozaUpsertRequest, Database.Dijagnoza>();
            CreateMap<VrstaArtiklaUpsertRequest, Database.VrstaArtikla>();
            CreateMap<UposlenikInsertRequest, Database.Uposlenik>();
            CreateMap<KorisnickiRacunInsertRequest, Database.Klijent>();
            CreateMap<KlijentUpdateRequest, Database.Klijent>();
            CreateMap<UposlenikUpdateRequest, Database.Uposlenik>();
            CreateMap<SpolUpsertRequest, Database.Spol>();
            CreateMap<TerminInsertRequest, Database.Termin>();
            CreateMap<TerminUpdateRequest, Database.Termin>();
            CreateMap<NovostUpsertRequest, Database.Novost>();
            CreateMap<RacunInsertRequest, Database.Racun>();
            CreateMap<RacunUpdateRequest, Database.Racun>();


            CreateMap<Database.KorisnickiRacun, KorisnickiRacunInsertRequest>().ReverseMap();
            CreateMap<Database.KorisnickiRacun, KlijentUpdateRequest>().ReverseMap();
            CreateMap<Database.KorisnickiRacun, UposlenikUpdateRequest>().ReverseMap();
            CreateMap<Database.KorisnickiRacun, AuthKorisnickiRacun>().ReverseMap();
            CreateMap<Database.Klijent, KlijentInsertRequest>().ReverseMap();
            CreateMap<Model.Klijent, Database.KorisnickiRacun>().ReverseMap();
            CreateMap<Model.Klijent, KlijentInsertRequest>().ReverseMap();
            CreateMap<Model.Uposlenik, UposlenikInsertRequest>().ReverseMap();
            CreateMap<Database.Uposlenik, UposlenikInsertRequest>().ReverseMap();


            CreateMap<Database.Klijent, Model.Klijent>()
               .ForMember(s => s.Ime, x => x.MapFrom(y => y.KorisnickiRacun.Ime))
               .ForMember(s => s.Prezime, x => x.MapFrom(y => y.KorisnickiRacun.Prezime))
               .ForMember(s => s.Email, x => x.MapFrom(y => y.KorisnickiRacun.Email))
               .ForMember(s => s.BrojTelefona, x => x.MapFrom(y => y.KorisnickiRacun.BrojTelefona))
               .ForMember(s => s.KorisnickoIme, x => x.MapFrom(y => y.KorisnickiRacun.KorisnickoIme))
               .ForMember(s => s.Adresa, x => x.MapFrom(y => y.KorisnickiRacun.Adresa))
               .ForMember(s => s.DatumRodjenja, x => x.MapFrom(y => y.KorisnickiRacun.DatumRodjenja))
               .ReverseMap();

            CreateMap<Database.Uposlenik, Model.Uposlenik>()
                .ForMember(s => s.Ime, x => x.MapFrom(y => y.KorisnickiRacun.Ime))
                .ForMember(s => s.Prezime, x => x.MapFrom(y => y.KorisnickiRacun.Prezime))
                .ForMember(s => s.Email, x => x.MapFrom(y => y.KorisnickiRacun.Email))
                .ForMember(s => s.BrojTelefona, x => x.MapFrom(y => y.KorisnickiRacun.BrojTelefona))
                .ForMember(s => s.KorisnickoIme, x => x.MapFrom(y => y.KorisnickiRacun.KorisnickoIme))
                .ForMember(s => s.Adresa, x => x.MapFrom(y => y.KorisnickiRacun.Adresa))
                .ForMember(s => s.DatumRodjenja, x => x.MapFrom(y => y.KorisnickiRacun.DatumRodjenja))
                .ForMember(s => s.RoleNames, x => x.MapFrom(y => string.Join(", ", y.UposlenikRolas.Select(x => x.Rola.Naziv).ToList())))
                
                .ReverseMap();
        }
    }
}
