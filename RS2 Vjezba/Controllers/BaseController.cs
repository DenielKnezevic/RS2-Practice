using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Services;

namespace RS2_Vjezba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<T , TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IService<T , TSearch> _service;

        public BaseController(IService<T , TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<T> Get([FromQuery]TSearch search = null)
        {
            return this._service.Get(search);
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return this._service.GetById(id);
        }

    }
}
