using Microsoft.AspNetCore.Authorization;
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
        public IProizvodiService ProizvodiService { get; set; }
        public ProizvodiController(IProizvodiService service)
            : base(service)
        {
            ProizvodiService = service;
        }

        [HttpPut("{id}/Activate")]
        public RS2_Vjezbe.Models.Proizvodi Activate(int id)
        {
            return ProizvodiService.Activate(id);
        }

        [HttpPut("{id}/Hide")]
        public RS2_Vjezbe.Models.Proizvodi Hide(int id)
        {
            return ProizvodiService.Hide(id);
        }

        [HttpPut("{id}/Delete")]
        public ActionResult<string> Delete(int id)
        {
            ProizvodiService.Delete(id);

            return "Product deleted successfully";
        }

        [HttpPut("{id}/AllowedActions")]
        public List<string> AllowedActions(int id)
        {
            return ProizvodiService.AllowedActions(id);
        }
        [AllowAnonymous]
        [HttpGet("{id}/Recommend")]
        public List<RS2_Vjezbe.Models.Proizvodi> Recommend(int id)
        {
            return ProizvodiService.Recommend(id);
        }
    }
}
