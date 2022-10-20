using AutoMapper;
using eOftamoloskiCentar.Model.Requests;
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
        }
    }
}
