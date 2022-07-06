using AutoMapper;
using RS2_Vjezba.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class BaseService<T, TDb> : IService<T> where T : class where TDb : class
    {
        private readonly eProdajaContext Context;
        private IMapper _mapper;

        public BaseService(eProdajaContext context , IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<T> Get()
        {
            var entity = Context.Set<TDb>().ToList();

            return _mapper.Map<IEnumerable<T>>(entity);
        }

        public T GetById(int id)
        {
            var entity = Context.Set<TDb>().Find(id);

            return _mapper.Map<T>(entity);
        }
    }
}
