using AutoMapper;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Services.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services.ArtikalStateMachine
{
    public class BaseState
    {
        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public BaseState(IServiceProvider serviceProvider, OftamoloskiCentarContext context, IMapper mapper)
        {
            Context = context;
            ServiceProvider = serviceProvider;
            Mapper = mapper;
        }
        public Database.Artikal CurrentEntity { get; set; }
        public string CurrentState { get; set; }
        public OftamoloskiCentarContext Context { get; set; } = null;
        public virtual Model.Artikal Insert (ArtikalInsertRequest request)
        {
            throw new Exception("Not allowed");
        }
        public virtual void Update(ArtikalUpdateRequest request)
        {
            throw new Exception("Not allowed");
        }
        public virtual void Activate()
        {
            throw new Exception("Not allowed");
        }
        public virtual void Hide()
        {
            throw new Exception("Not allowed");
        }
        public virtual void Delete()
        {
            throw new Exception("Not allowed");
        }
        public BaseState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialArtikalState>();
                    break;
                case "draft":
                    return ServiceProvider.GetService<DraftArtikalState>();
                case "active":
                    return ServiceProvider.GetService<ActiveArtikalState>();
                default:
                    throw new Exception("Not supported");
            }
        }
        public virtual List<string> AllowedActions()
        {
            return new List<string>();
        }
    }
}
