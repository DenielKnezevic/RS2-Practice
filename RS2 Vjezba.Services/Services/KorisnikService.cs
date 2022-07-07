using AutoMapper;
using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class KorisnikService : BaseService<RS2_Vjezbe.Models.Korisnici,Database.Korisnici, RS2_Vjezbe.Models.KorisniciSearchObject>, IKorisnikService
    {

        public KorisnikService(eProdajaContext context , IMapper mapper)
            : base(context ,mapper)
        {
        }

        public override IQueryable<Database.Korisnici> AddFilter(IQueryable<Database.Korisnici> query, KorisniciSearchObject search = null)
        {
            if (!string.IsNullOrEmpty(search.Ime))
            {

                query = query.Where(x => x.Ime.Contains(search.Ime));
            }

            if (!string.IsNullOrEmpty(search.Prezime))
            {

                query = query.Where(x => x.Prezime.Contains(search.Prezime));
            }

            return query;
        }
    }
}
