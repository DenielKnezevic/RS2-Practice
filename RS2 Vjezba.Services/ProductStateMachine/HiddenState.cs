using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.ProductStateMachine
{
    public class HiddenState : BaseState
    {
        public override void Activate()
        {
            CurrentEntity.StateMachine = "Active";
        }

        public override void Update(int id, ProizvodiUpdateRequest request)
        {
            CurrentEntity.StateMachine = "Hidden";
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
