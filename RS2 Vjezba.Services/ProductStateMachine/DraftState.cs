using AutoMapper;
using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.ProductStateMachine
{
    public class DraftState : BaseState
    {
        public DraftState(IServiceProvider serviceProvider, eProdajaContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {

        }
        public override void Activate()
        {
            CurrentEntity.StateMachine = "Active";

            Context.SaveChanges();
        }

        public override RS2_Vjezbe.Models.Proizvodi Update(ProizvodiUpdateRequest request)
        {
            var set = Context.Set<Proizvodi>();

            Mapper.Map(request, CurrentEntity);

            CurrentEntity.StateMachine = "Draft";

            Context.SaveChanges();

            return Mapper.Map<RS2_Vjezbe.Models.Proizvodi>(CurrentEntity);
            
        }

        public override List<string> AllowedActions()
        {
            var list = base.AllowedActions();

            list.Add("Activate");
            list.Add("Update");

            return list;
        }
    }
}
