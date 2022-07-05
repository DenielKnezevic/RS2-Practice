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

        public KorisnikService(eProdajaContext context)
        {
            Context = context;
        }

        public IEnumerable<Korisnici> Get()
        {
            return Context.Korisnicis.ToList();
        }

        public Korisnici GetById(int id)
        {
            var model = Context.Korisnicis.FirstOrDefault(x => x.KorisnikId == id);

            return model;
        }
    }
}
