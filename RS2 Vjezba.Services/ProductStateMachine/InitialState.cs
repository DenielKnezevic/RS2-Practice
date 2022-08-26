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
    public class InitialState : BaseState
    {

        public InitialState(IServiceProvider serviceProvider , eProdajaContext context , IMapper mapper):base(serviceProvider , context , mapper)
        {

        }
        public override RS2_Vjezbe.Models.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            var set = Context.Set<Proizvodi>();

            Proizvodi entity = Mapper.Map<Proizvodi>(request);

            set.Add(entity);

            entity.StateMachine = "Draft";

            Context.SaveChanges();

            return Mapper.Map<RS2_Vjezbe.Models.Proizvodi>(entity);
        }

    }
}
