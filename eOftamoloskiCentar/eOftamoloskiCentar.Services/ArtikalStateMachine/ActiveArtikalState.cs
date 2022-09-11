using AutoMapper;
using eOftamoloskiCentar.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services.ArtikalStateMachine
{
    public class ActiveArtikalState : BaseState
    {
        public ActiveArtikalState(IServiceProvider serviceProvider, OftamoloskiCentarContext context, IMapper mapper)
            : base(serviceProvider, context, mapper)
        {
        }
    }
}
