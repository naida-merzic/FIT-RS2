using eOftamoloskiCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOftamoloskiCentar.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IService<T, TSearch> _service;

        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }
        [HttpGet]
        [Authorize]

        public virtual IEnumerable<T> Get([FromQuery]TSearch search = null)
        {
            return _service.Get(search);
        }

        [HttpGet("{Id}")]
        [Authorize]

        public virtual T GetById(int Id)
        {
            return _service.GetById(Id);
        }
    }
}