using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Interfaces
{
    internal interface IMarketService
    {
        Task<IEnumerable<MarketModel>> GetAll();

        Task<MarketModel> Get(Guid id);

        Task<int> Update(MarketModel item);

        Task<int> Delete(Guid id);

        Task<int> Add(MarketModel item);
    }
}
