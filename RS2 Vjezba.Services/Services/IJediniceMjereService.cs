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
    public interface IJediniceMjereService : ICRUDService<RS2_Vjezbe.Models.JediniceMjere , RS2_Vjezbe.Models.JediniceMjereSearchObject , JediniceMjereUpsertRequest , JediniceMjereUpsertRequest>
    {
    }
}
