﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;

namespace RS2_Vjezba.Controllers
{
    public class KorisniciController : BaseController<RS2_Vjezbe.Models.Korisnici>
    {
        public KorisniciController(IKorisnikService service)
            : base(service)
        {
        }
    }
}
