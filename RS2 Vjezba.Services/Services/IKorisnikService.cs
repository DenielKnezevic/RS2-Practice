using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public interface IKorisnikService
    {
        IEnumerable<RS2_Vjezbe.Models.Korisnici> Get();
        RS2_Vjezbe.Models.Korisnici GetById(int id);
    }
}
