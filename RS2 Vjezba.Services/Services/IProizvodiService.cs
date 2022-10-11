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
    public interface IProizvodiService : ICRUDService<RS2_Vjezbe.Models.Proizvodi, RS2_Vjezbe.Models.ProizvodiSearchObject , ProizvodiInsertRequest , ProizvodiUpdateRequest>
    {
        RS2_Vjezbe.Models.Proizvodi Activate(int id);
        RS2_Vjezbe.Models.Proizvodi Hide(int id);
        void Delete(int id);
        List<string> AllowedActions(int id);
        List<RS2_Vjezbe.Models.Proizvodi> Recommend(int id);
    }
}
