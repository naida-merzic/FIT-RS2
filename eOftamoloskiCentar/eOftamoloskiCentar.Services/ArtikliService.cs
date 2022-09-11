using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.ArtikalStateMachine;
using eOftamoloskiCentar.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services 
{
    public class ArtikliService : BaseCRUDService<Model.Artikal, Database.Artikal, ArtikalSearchObject, ArtikalInsertRequest, ArtikalUpdateRequest>, IArtikliService
    {
        public BaseState BaseState { get; set; }
        public ArtikliService(OftamoloskiCentarContext context, IMapper mapper, BaseState baseState)
            : base(context, mapper)
        {
            BaseState = baseState;
        }
        public override Model.Artikal Insert(ArtikalInsertRequest insert)
        {
            //return base.Insert(insert);
            var state = BaseState.CreateState("initial");

            return state.Insert(insert);
        }

        public override Model.Artikal Update(int id, ArtikalUpdateRequest update)
        {
            var product = Context.Artikals.Find(id);
            //return base.Update(id, update);
            var state = BaseState.CreateState(product.StateMachine);
            state.CurrentEntity = product;

            state.Update(update);

            return GetById(id);
        }

        public Model.Artikal Activate(int id)
        {
            var product = Context.Artikals.Find(id);
            //return base.Update(id, update);
            var state = BaseState.CreateState(product.StateMachine);
            state.CurrentEntity = product;

            state.Activate();

            return GetById(id);
        }
        public List<string> AllowedActions(int id)
        {
            var product = GetById(id);
            var state = BaseState.CreateState(product.StateMachine);

            return state.AllowedActions();
        }
        public override IEnumerable<Model.Artikal> Get(ArtikalSearchObject search = null)
        {
            return base.Get(search);
        }

        public override IQueryable<Database.Artikal> AddFilter(IQueryable<Database.Artikal>query, ArtikalSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv == search.Naziv);
            }
            return filteredQuery;
        }
    }
}
