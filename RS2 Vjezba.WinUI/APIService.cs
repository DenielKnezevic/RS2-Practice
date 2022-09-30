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
        public static string Username = null;
        public static string Password = null;
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

            var list = await $"{Endpoint}{Resource}?{query}".WithBasicAuth(Username,Password).GetJsonAsync<T>();

            return list;
        }

        public async Task<T> GetById<T>(object id)
        {
            var product = await $"{Endpoint}{Resource}/{id}".GetJsonAsync<T>();

            return product;
        }

        public async Task<T> Post<T>(object entity)
        {
            try
            {
                var product = await $"{Endpoint}{Resource}".WithBasicAuth(Username, Password).PostJsonAsync(entity).ReceiveJson<T>();

                return product;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<T> Put<T>(object id, object entity)
        {
            try
            {
                var product = await $"{Endpoint}{Resource}/{id}".WithBasicAuth(Username, Password).PutJsonAsync(entity).ReceiveJson<T>();

                return product;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
    }
}
