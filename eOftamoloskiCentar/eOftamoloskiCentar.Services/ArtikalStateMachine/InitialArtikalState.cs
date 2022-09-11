using AutoMapper;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services.ArtikalStateMachine
{
    public class InitialArtikalState : BaseState
    {
        public InitialArtikalState(IServiceProvider serviceProvider, OftamoloskiCentarContext context, IMapper mapper)
            : base(serviceProvider, context, mapper)
        {

        }
        public override Model.Artikal Insert(ArtikalInsertRequest request)
        {
            var set = Context.Set<Database.Artikal>();

            Database.Artikal entity = Mapper.Map<Database.Artikal>(request);

            CurrentEntity = entity;
            CurrentEntity.StateMachine = "draft";

            set.Add(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Artikal>(entity);
        }
    }
}
