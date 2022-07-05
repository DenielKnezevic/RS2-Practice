using AutoMapper;
using RS2_Vjezba.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class ProizvodiService : IProizvodiService
    {
        private readonly eProdajaContext Context;
        private IMapper _mapper;

        public ProizvodiService(eProdajaContext context , IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<RS2_Vjezbe.Models.Proizvodi> Get()
        {
            return _mapper.Map<IEnumerable<RS2_Vjezbe.Models.Proizvodi>>(Context.Proizvodis.ToList());
        }

        public RS2_Vjezbe.Models.Proizvodi GetById(int id)
        {
            var model = _mapper.Map<RS2_Vjezbe.Models.Proizvodi>(Context.Proizvodis.FirstOrDefault(x => x.ProizvodId == id));

            return model;
        }
    }
}
