using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;
using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;

namespace RS2_Vjezba.Controllers
{
    public class ProizvodiController : CRUDController<RS2_Vjezbe.Models.Proizvodi , ProizvodiSearchObject , ProizvodiInsertRequest , ProizvodiUpdateRequest>
    {
        public ProizvodiController(IProizvodiService service)
            : base(service)
        {
        }
    }
}
