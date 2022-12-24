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
    public class DraftArtikalState : BaseState
    {
        public DraftArtikalState(IServiceProvider serviceProvider, OftamoloskiCentarContext context, IMapper mapper)
            : base(serviceProvider, context, mapper)
        {
        }

        public override void Update(ArtikalUpdateRequest request)
        {
            var set = Context.Set<Database.Artikal>();

            Mapper.Map(request, CurrentEntity);
            CurrentEntity.StateMachine = "draft";

            Context.SaveChanges();
        }

        public override void Activate()
        {
            CurrentEntity.StateMachine = "active";
            Context.SaveChanges();
        }
        public override List<string> AllowedActions()
        {
            var list = base.AllowedActions();

            list.Add("update");
            list.Add("activate");
            list.Add("hide");

            return list;
        }
    }
}
