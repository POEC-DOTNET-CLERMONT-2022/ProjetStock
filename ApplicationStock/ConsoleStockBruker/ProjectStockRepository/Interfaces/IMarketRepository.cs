using ProjectStockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Interfaces
{
    internal interface IMarketRepository
    {
        MarketEntity? Add(MarketEntity marketEntity);

        MarketEntity? Update(MarketEntity marketEntity);


        bool Delete(Guid id);


        MarketEntity? GetSingle(Guid id);
    }
}
