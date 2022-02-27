using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        T? Add(T notifEntity);

        T? Update(T notifEntity);

        bool Delete(T entity);

        IEnumerable<T> GetAll();

       
    }
}
