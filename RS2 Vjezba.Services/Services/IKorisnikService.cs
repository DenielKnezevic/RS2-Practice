using RS2_Vjezba.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public interface IKorisnikService
    {
        IEnumerable<Korisnici> Get();
        Korisnici GetById(int id);
    }
}
