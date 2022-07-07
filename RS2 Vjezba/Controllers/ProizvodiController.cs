using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;
using RS2_Vjezbe.Models;

namespace RS2_Vjezba.Controllers
{
    public class ProizvodiController : BaseController<RS2_Vjezbe.Models.Proizvodi , ProizvodiSearchObject>
    {
        public ProizvodiController(IProizvodiService service)
            : base(service)
        {
        }
    }
}
