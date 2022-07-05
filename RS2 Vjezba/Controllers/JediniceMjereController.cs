using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;

namespace RS2_Vjezba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JediniceMjereController : ControllerBase
    {
        private IJediniceMjereService _service;

        public JediniceMjereController(IJediniceMjereService service)
        {
            _service = service; 
        }

        [HttpGet]
        public IEnumerable<RS2_Vjezbe.Models.JediniceMjere> Get()
        {
            return this._service.Get();
        }

        [HttpGet("{id}")]
        public RS2_Vjezbe.Models.JediniceMjere GetById(int id)
        {
            return this._service.GetById(id);
        }

    }
}
