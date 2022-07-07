using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;
using RS2_Vjezbe.Models;

namespace RS2_Vjezba.Controllers
{
    public class KorisniciController : BaseController<RS2_Vjezbe.Models.Korisnici , KorisniciSearchObject>
    {
        public KorisniciController(IKorisnikService service)
            : base(service)
        {
        }
    }
}
