using AutoMapper;
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
            CreateMap<Database.Termin, Model.Termin>();
            CreateMap<Database.Novost, Model.Novost>();
            CreateMap<Database.Racun, Model.Racun>();
            CreateMap<Database.StavkaRacuna, Model.StavkaRacuna>();
            CreateMap<Database.KorisnickiRacun, Model.KorisnickiRacun>();
            CreateMap<KorisnickiRacun, Model.AuthKorisnickiRacun>().ReverseMap();
            


            CreateMap<ArtikalInsertRequest, Database.Artikal>();
            CreateMap<ArtikalUpdateRequest, Database.Artikal>();
            CreateMap<DijagnozaUpsertRequest, Database.Dijagnoza>();
            CreateMap<VrstaArtiklaUpsertRequest, Database.VrstaArtikla>();
            CreateMap<UposlenikInsertRequest, Database.Uposlenik>();
            CreateMap<UposlenikUpdateRequest, Database.Uposlenik>();
            CreateMap<KlijentInsertRequest, Database.Klijent>();
            CreateMap<KlijentUpdateRequest, Database.Klijent>();
            CreateMap<SpolUpsertRequest, Database.Spol>();
            CreateMap<TerminInsertRequest, Database.Termin>();
            CreateMap<TerminUpdateRequest, Database.Termin>();
            CreateMap<NovostUpsertRequest, Database.Novost>();
            CreateMap<RacunInsertRequest, Database.Racun>();
            CreateMap<RacunUpdateRequest, Database.Racun>();


            CreateMap<KorisnickiRacun, KlijentInsertRequest>().ReverseMap();
            CreateMap<KorisnickiRacun, KlijentUpdateRequest>().ReverseMap();


            CreateMap<Klijent, Model.Klijent>()
               .ForMember(s => s.Ime, x => x.MapFrom(y => y.KorisnickiRacun.Ime))
               .ForMember(s => s.Prezime, x => x.MapFrom(y => y.KorisnickiRacun.Prezime))
               /*.ForMember(s => s.Email, x => x.MapFrom(y => y.KorisnickiRacun.Email))
               .ForMember(s => s.Telefon, x => x.MapFrom(y => y.KorisnickiRacun.Telefon))*/
               .ForMember(s => s.KorisnickoIme, x => x.MapFrom(y => y.KorisnickiRacun.KorisnickoIme))
               /*.ForMember(s => s.Adresa, x => x.MapFrom(y => y.KorisnickiRacun.Adresa))
               .ForMember(s => s.DatumRodjenja, x => x.MapFrom(y => y.KorisnickiRacun.DatumRodjenja))*/
               .ReverseMap();

            /*CreateMap<Uposlenik, Model.Uposlenik>()
                .ForMember(s => s.Ime, x => x.MapFrom(y => y.KorisnickiRacun.Ime))
                .ForMember(s => s.Prezime, x => x.MapFrom(y => y.KorisnickiRacun.Prezime))
                .ForMember(s => s.Email, x => x.MapFrom(y => y.KorisnickiRacun.Email))
                .ForMember(s => s., x => x.MapFrom(y => y.KorisnickiRacun.Telefon))
                .ForMember(s => s.KorisnickoIme, x => x.MapFrom(y => y.KorisnickiRacun.KorisnickoIme))
                .ForMember(s => s.Adresa, x => x.MapFrom(y => y.KorisnickiRacun.Adresa))
                .ForMember(s => s.DatumRodjenja, x => x.MapFrom(y => y.KorisnickiRacun.DatumRodjenja))
                .ForMember(s => s.SlikaPutanja, x => x.MapFrom(y => y.KorisnickiRacun.SlikaPutanja))
                .ReverseMap();*/
        }
    }
}
