using AutoMapper;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.ProductStateMachine;
using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class ProizvodiService : CRUDService<RS2_Vjezbe.Models.Proizvodi,Database.Proizvodi , RS2_Vjezbe.Models.ProizvodiSearchObject , ProizvodiInsertRequest , ProizvodiUpdateRequest>, IProizvodiService
    {
        public ProizvodiService(eProdajaContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public override RS2_Vjezbe.Models.Proizvodi Insert(ProizvodiInsertRequest insert)
        {
            var state = BaseState.CreateState("initial");
            state.Context = Context;
            state.Insert(insert);

            return base.Insert(insert);
        }

        public override RS2_Vjezbe.Models.Proizvodi Update(int id, ProizvodiUpdateRequest update)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;
            state.Context = Context;
            state.Update(id,update);

            return GetById(id);

            //return base.Update(id, update);
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
