using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;
using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;

namespace RS2_Vjezba.Controllers
{
    public class KorisniciController : CRUDController<RS2_Vjezbe.Models.Korisnici , KorisniciSearchObject , KorisniciInsertRequest , KorisniciUpdateRequest>
    {
        public KorisniciController(IKorisnikService service)
            : base(service)
        {
        }
    }
}
