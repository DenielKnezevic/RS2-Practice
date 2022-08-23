using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.ProductStateMachine
{
    public class InitialState : BaseState
    {
        public override void Insert(ProizvodiInsertRequest request)
        {
            CurrentEntity.StateMachine = "Draft";
        }

    }
}
