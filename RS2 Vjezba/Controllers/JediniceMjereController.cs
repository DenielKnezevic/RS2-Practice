using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;

namespace RS2_Vjezba.Controllers
{
    public class JediniceMjereController : BaseController<RS2_Vjezbe.Models.JediniceMjere>
    {
        public JediniceMjereController(IJediniceMjereService service)
            :base(service)
        {
        }

    }
}
