using AutoMapper;
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
    public class VrsteProizvodumService : CRUDService<RS2_Vjezbe.Models.VrsteProizvodum,Database.VrsteProizvodum , RS2_Vjezbe.Models.VrsteProizvodumSearchObject , VrsteProizvodumUpsertRequest , VrsteProizvodumUpsertRequest>, IVrsteProizvodumService
    {
        public VrsteProizvodumService(eProdajaContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public override IQueryable<Database.VrsteProizvodum> AddFilter(IQueryable<Database.VrsteProizvodum> query, VrsteProizvodumSearchObject search = null)
        {
            if (!string.IsNullOrEmpty(search.Naziv))
            {

                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }
            return query;
        }
    }
}
