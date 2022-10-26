using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IService<T, TSearch> _service;

        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery]TSearch search = null)
        {
            return _service.Get(search);
        }

        [HttpGet("{Id}")]
        public virtual T GetById(int Id)
        {
            return _service.GetById(Id);
        }
    }
}