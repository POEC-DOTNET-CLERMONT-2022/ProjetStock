using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Interfaces
{
   public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetAll();

        Task<OrderModel> Get(Guid id);
        Task<int> Update(OrderModel item);


        Task<int> Delete(Guid id);
        Task<int> Add(OrderModel item);
    }
}
