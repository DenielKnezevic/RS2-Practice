using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public interface IProizvodiService : IService<RS2_Vjezbe.Models.Proizvodi, RS2_Vjezbe.Models.ProizvodiSearchObject>
    {
    }
}
