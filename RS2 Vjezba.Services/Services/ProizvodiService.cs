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
    public class ProizvodiService : BaseService<RS2_Vjezbe.Models.Proizvodi,Database.Proizvodi , RS2_Vjezbe.Models.ProizvodiSearchObject>, IProizvodiService
    {
        public ProizvodiService(eProdajaContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public override IQueryable<Database.Proizvodi> AddFilter(IQueryable<Database.Proizvodi> query, ProizvodiSearchObject search = null)
        {
            if (!string.IsNullOrEmpty(search.Naziv))
            {

                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (!string.IsNullOrEmpty(search.Sifra))
            {

                query = query.Where(x => x.Sifra == search.Sifra);
            }

            return query;
        }
    }
}
