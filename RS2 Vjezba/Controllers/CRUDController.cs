using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Vjezba.Services.Services;

namespace RS2_Vjezba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController<T , TSearch , TInsert , TUpdate> : BaseController<T,TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public CRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service)
            :base(service)
        {

        }

        [HttpPost]
        public T Insert([FromBody] TInsert insert)
        {
            return ((ICRUDService<T, TSearch, TInsert, TUpdate>)_service).Insert(insert);

        }

        [HttpPut("{id}")]
        public T Update(int id ,[FromBody] TUpdate update)
        {
            return ((ICRUDService<T, TSearch, TInsert, TUpdate>)_service).Update(id , update);
        }
    }
}
