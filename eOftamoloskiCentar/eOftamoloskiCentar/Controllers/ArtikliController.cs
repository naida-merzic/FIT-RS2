using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    public class ArtikliController : BaseCRUDController<Model.Artikal, ArtikalSearchObject, ArtikalInsertRequest, ArtikalUpdateRequest>
    {
        public IArtikliService ArtikliService { get; set; }
        public ArtikliController(IArtikliService service)
            : base(service) 
        {
            ArtikliService = service;
        }

        [HttpPut("{id}/Activate")]
        public Model.Artikal Activate(int id)
        {
            var result = ArtikliService.Activate(id);

            return result;
        }
        [HttpPut("{id}/AllowedActions")]
        public List<string> AllowedActions(int id)
        {
            var result = ArtikliService.AllowedActions(id);

            return result;
        }

        [HttpGet("{id}/Recommend")]
        [AllowAnonymous]
        public List<Artikal> Recommend(int id)
        {
            var result = ArtikliService.Recommend(id);

            return result;
        }
    }
}   
    