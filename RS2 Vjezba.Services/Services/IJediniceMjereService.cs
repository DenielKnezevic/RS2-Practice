using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public interface IJediniceMjereService
    {
        IEnumerable<RS2_Vjezbe.Models.JediniceMjere> Get();
        RS2_Vjezbe.Models.JediniceMjere GetById(int id);
    }
}
