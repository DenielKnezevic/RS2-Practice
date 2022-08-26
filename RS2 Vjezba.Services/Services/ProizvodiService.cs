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
        public BaseState BaseState { get; set; }
        public ProizvodiService(eProdajaContext context, IMapper mapper , BaseState baseState)
            : base(context, mapper)
        {
            BaseState = baseState;
        }

        public override RS2_Vjezbe.Models.Proizvodi Insert(ProizvodiInsertRequest insert)
        {
            var state = BaseState.CreateState("initial");

            return state.Insert(insert);
        }

        public override RS2_Vjezbe.Models.Proizvodi Update(int id, ProizvodiUpdateRequest update)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Update(update);

            return GetById(id);

            //return base.Update(id, update);
        }

        public RS2_Vjezbe.Models.Proizvodi Activate(int id)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Activate();

            return GetById(id);

        }

        public RS2_Vjezbe.Models.Proizvodi Hide(int id)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Hide();

            return GetById(id);

        }

        public void Delete(int id)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Delete();
        }

        public List<string> AllowedActions(int id)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            var list = state.AllowedActions();

            return list;
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
