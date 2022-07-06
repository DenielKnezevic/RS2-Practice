using AutoMapper;
using RS2_Vjezba.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class KorisnikService : BaseService<RS2_Vjezbe.Models.Korisnici,Database.Korisnici>, IKorisnikService
    {

        public KorisnikService(eProdajaContext context , IMapper mapper)
            : base(context ,mapper)
        {
        }
    }
}
