using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Services;

namespace RS2_Vjezba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IService<T> _service;

        public BaseController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<T> Get()
        {
            return this._service.Get();
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return this._service.GetById(id);
        }

    }
}
