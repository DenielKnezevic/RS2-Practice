using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.ProductStateMachine
{
    public class ActiveState : BaseState
    {
        public override void Hide()
        {
            CurrentEntity.StateMachine = "Hidden";
        }


    }
}
