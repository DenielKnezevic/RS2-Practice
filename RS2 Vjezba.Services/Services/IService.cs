using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> Get();
        T GetById(int id);
    }
}
