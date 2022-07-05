using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;

namespace RS2_Vjezba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodiController : ControllerBase
    {
        private IProizvodiService _service;

        public ProizvodiController(IProizvodiService service)
        {
            _service = service; 
        }

        [HttpGet]
        public IEnumerable<RS2_Vjezbe.Models.Proizvodi> Get()
        {
            return this._service.Get();
        }

        [HttpGet("{id}")]
        public RS2_Vjezbe.Models.Proizvodi GetById(int id)
        {
            return this._service.GetById(id);
        }

    }
}
