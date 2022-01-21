using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Interfaces
{
    internal interface IStockService
    {
        Task<IEnumerable<StockModel>> GetAll();

        Task<StockModel> Get(Guid id);
        Task<int> Update(StockModel item);


        Task<int> Delete(Guid id);
        Task<int> Add(StockModel item);
    }
}
