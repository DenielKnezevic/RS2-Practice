using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.ProductStateMachine
{
    public abstract class BaseState
    {
        public eProdajaContext Context { get; set; }
        public Database.Proizvodi CurrentEntity { get; set; }

        public virtual void Update(int id, ProizvodiUpdateRequest request)
        {
            throw new Exception("Not allowed");
        }

        public virtual void Insert(ProizvodiInsertRequest request)
        {
            throw new Exception("Not allowed");
        }

        public virtual void Activate()
        {
            throw new Exception("Not allowed");
        }

        public virtual void Hide()
        {
            throw new Exception("Not allowed");
        }

        public virtual void Delete()
        {
            throw new Exception("Not allowed");
        }

        public static BaseState CreateState(string state)
        {
            switch(state)
            {
                case "initial":
                    return new InitialState();
                    break;
                case "active":
                    return new ActiveState();
                    break;
                case "draft":
                    return new DraftState();
                    break;
                case "hidden":
                    return new HiddenState();
                default: throw new Exception("Not specified");
                    break;
                    
            }
        }
    }
}
