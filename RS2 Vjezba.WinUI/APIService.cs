using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS2_Vjezbe.Models;

namespace RS2_Vjezba.WinUI
{
    public class APIService
    {
        public string Endpoint = "http://localhost:46268/api/";
        public string Resource;

        public APIService(string resource)
        {
            Resource = resource;
        }

        public async Task<T> GetData<T>(object search = null)
        {
            var query = "";

            if(search != null)
            {
                query = await search.ToQueryString(); 
            }

            var list = await $"{Endpoint}{Resource}?{query}".GetJsonAsync<T>();

            return list;
        }

        public async Task<T> GetById<T>(object id)
        {
            var product = await $"{Endpoint}{Resource}/{id}".GetJsonAsync<T>();

            return product;
        }

        public async Task<T> Post<T>(object entity)
        {
            var product = await $"{Endpoint}{Resource}".PostJsonAsync(entity).ReceiveJson<T>();

            return product;
        }

        public async Task<T> Put<T>(object id, object entity)
        {
            var product = await $"{Endpoint}{Resource}/{id}".PutJsonAsync(entity).ReceiveJson<T>();

            return product;
        }
    }
}
