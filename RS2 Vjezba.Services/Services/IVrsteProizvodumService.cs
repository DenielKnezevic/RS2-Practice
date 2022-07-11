using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public interface IVrsteProizvodumService : ICRUDService<RS2_Vjezbe.Models.VrsteProizvodum , RS2_Vjezbe.Models.VrsteProizvodumSearchObject , VrsteProizvodumUpsertRequest, VrsteProizvodumUpsertRequest>
    {
    }
}
