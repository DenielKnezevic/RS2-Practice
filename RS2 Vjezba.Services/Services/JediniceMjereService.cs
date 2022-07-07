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
    public class JediniceMjereService : BaseService<RS2_Vjezbe.Models.JediniceMjere , Database.JediniceMjere, RS2_Vjezbe.Models.JediniceMjereSearchObject> , IJediniceMjereService
    {
        public JediniceMjereService(eProdajaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public override IQueryable<Database.JediniceMjere> AddFilter(IQueryable<Database.JediniceMjere> query, JediniceMjereSearchObject search = null)
        {
            if(!string.IsNullOrEmpty(search.Naziv))
                {

                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            return query;
        }

    }
}
