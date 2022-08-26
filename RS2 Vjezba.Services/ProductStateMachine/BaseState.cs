using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.ProductStateMachine
{
    public class BaseState
    {
        public eProdajaContext Context { get; set; }
        public Database.Proizvodi CurrentEntity { get; set; }
        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public BaseState(IServiceProvider serviceProvider , eProdajaContext context , IMapper mapper)
        {
            ServiceProvider = serviceProvider;
            Context = context;
            Mapper = mapper;
        }

        public virtual RS2_Vjezbe.Models.Proizvodi Update(ProizvodiUpdateRequest request)
        {
            throw new Exception("Not allowed");
        }

        public virtual RS2_Vjezbe.Models.Proizvodi Insert(ProizvodiInsertRequest request)
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

        public BaseState CreateState(string state)
        {
            switch(state)
            {
                case "Initial":
                    return ServiceProvider.GetService<InitialState>();
                    break;
                case "Active":
                    return ServiceProvider.GetService<ActiveState>();
                    break;
                case "Draft":
                    return ServiceProvider.GetService<DraftState>();
                    break;
                case "Hidden":
                    return ServiceProvider.GetService<HiddenState>();
                default: 
                    throw new Exception("Not specified");
                    break;
                    
            }
        }

        public virtual List<string> AllowedActions()
        {
            return new List<string>();
        }
    }
}
