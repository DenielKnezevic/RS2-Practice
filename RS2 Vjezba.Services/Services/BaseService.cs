﻿using AutoMapper;
using RS2_Vjezba.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class BaseService<T, TDb , TSearch> : IService<T , TSearch> where T : class where TDb : class where TSearch : class
    {
        private readonly eProdajaContext Context;
        private IMapper _mapper;

        public BaseService(eProdajaContext context , IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var entity = Context.Set<TDb>().ToList().AsQueryable() ;

            entity = AddFilter(entity, search);

            return _mapper.Map<IEnumerable<T>>(entity);
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query , TSearch search = null)
        {
            return query;
        }

        public T GetById(int id)
        {
            var entity = Context.Set<TDb>().Find(id);

            return _mapper.Map<T>(entity);
        }
    }
}
