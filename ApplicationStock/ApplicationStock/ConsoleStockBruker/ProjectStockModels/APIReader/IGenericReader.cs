using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Application.JsonReader
{
    internal interface IGenericReader<T> where T : class
    {
      
        Task<T> Get(T item);

        Task<T> Update(T item);
 

        Task<int> Delete(T item);
        Task<int> Add(T item);
    }
}
