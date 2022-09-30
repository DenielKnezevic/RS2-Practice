using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.Services;
using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;

namespace RS2_Vjezba.Controllers
{
    public class UlogeController : BaseController<RS2_Vjezbe.Models.Uloge , BaseSearchObject>
    {
        public UlogeController(IUlogeService service)
            :base(service)
        {
        }

    }
}
