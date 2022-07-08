using AutoMapper;
using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class CRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate>
        where T : class where TDb : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {

        public CRUDService(eProdajaContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public T Insert(TInsert insert)
        {
            var set = Context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(insert);

            set.Add(entity);

            Context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public T Update(int id , TUpdate update)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            _mapper.Map(update, entity);

            Context.SaveChanges();

            return _mapper.Map<T>(entity);
        }
    }
}
