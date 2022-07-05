using AutoMapper;
using RS2_Vjezba.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly eProdajaContext Context;
        private IMapper _mapper;

        public KorisnikService(eProdajaContext context , IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<RS2_Vjezbe.Models.Korisnici> Get()
        {
            return _mapper.Map<IEnumerable<RS2_Vjezbe.Models.Korisnici>>(Context.Korisnicis.ToList());
        }

        public RS2_Vjezbe.Models.Korisnici GetById(int id)
        {
            var model = _mapper.Map<RS2_Vjezbe.Models.Korisnici>(Context.Korisnicis.FirstOrDefault(x => x.KorisnikId == id));

            return model;
        }
    }
}
