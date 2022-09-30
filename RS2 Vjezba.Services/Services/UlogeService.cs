using AutoMapper;
using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class UlogeService : BaseService<RS2_Vjezbe.Models.Uloge , Database.Uloge, RS2_Vjezbe.Models.BaseSearchObject> , IUlogeService
    {
        public UlogeService(eProdajaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
