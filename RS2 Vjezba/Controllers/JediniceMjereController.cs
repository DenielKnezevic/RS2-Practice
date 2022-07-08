using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;
using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;

namespace RS2_Vjezba.Controllers
{
    public class JediniceMjereController : CRUDController<RS2_Vjezbe.Models.JediniceMjere , JediniceMjereSearchObject , JediniceMjereUpsertRequest , JediniceMjereUpsertRequest>
    {
        public JediniceMjereController(IJediniceMjereService service)
            :base(service)
        {
        }

    }
}
