using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplication.Profil.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T? Add(T Entity);

        T? Update(T Entity);

        bool Delete(T entity);

        List<T> GetAll();

        T GetById(Guid id);



    }
}
