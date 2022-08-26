using AutoMapper;
using RS2_Vjezba.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.ProductStateMachine
{
    public class ActiveState : BaseState
    {
        public ActiveState(IServiceProvider serviceProvider, eProdajaContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {

        }
        public override void Hide()
        {
            CurrentEntity.StateMachine = "Hidden";

            Context.SaveChanges();
        }

        public override List<string> AllowedActions()
        {
            var list = base.AllowedActions();

            list.Add("Hide");

            return list;
        }

    }
}
