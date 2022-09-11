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
            CreateMap<Database.Osoba, Model.Osoba>();
            CreateMap<Database.Artikal, Model.Artikal>();
            CreateMap<Database.Dijagnoza, Model.Dijagnoza>();
            CreateMap<Database.VrstaArtikla, Model.VrstaArtikla>();
            CreateMap<Database.Uposlenik, Model.Uposlenik>();



            CreateMap<ArtikalInsertRequest, Database.Artikal>();
            CreateMap<ArtikalUpdateRequest, Database.Artikal>();
            CreateMap<OsobaUpsertRequest, Database.Osoba>();
            CreateMap<DijagnozaUpsertRequest, Database.Dijagnoza>();
            CreateMap<VrstaArtiklaUpsertRequest, Database.VrstaArtikla>();
            CreateMap<UposlenikInsertRequest, Database.Uposlenik>();
            CreateMap<UposlenikUpdateRequest, Database.Uposlenik>();

        }
    }
}
