using AutoMapper;
using RS2_Vjezba.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class JediniceMjereService : IJediniceMjereService
    {
        private readonly eProdajaContext Context;
        private IMapper _mapper;

        public JediniceMjereService(eProdajaContext context , IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<RS2_Vjezbe.Models.JediniceMjere> Get()
        {
            return _mapper.Map<IEnumerable<RS2_Vjezbe.Models.JediniceMjere>>(Context.JediniceMjeres.ToList());
        }

        public RS2_Vjezbe.Models.JediniceMjere GetById(int id)
        {
            var model = _mapper.Map<RS2_Vjezbe.Models.JediniceMjere>(Context.JediniceMjeres.FirstOrDefault(x => x.JedinicaMjereId == id));

            return model;
        }
    }
}
