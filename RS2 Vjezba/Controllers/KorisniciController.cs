﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;

namespace RS2_Vjezba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private IKorisnikService _service;

        public KorisniciController(IKorisnikService service)
        {
            _service = service; 
        }

        [HttpGet]
        public IEnumerable<Korisnici> Get()
        {
            return this._service.Get();
        }

        [HttpGet("{id}")]
        public Korisnici GetById(int id)
        {
            return this._service.GetById(id);
        }

    }
}
