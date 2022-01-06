using System;
using System.Collections.Generic;
using System.Text;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace PersistanceStockProjectLibrary
{
    internal interface IMarketManager
    {
        IEnumerable<MarketDto> GetMarkets();

        MarketDto GetById(int id);
        IEnumerable<Market> GetAllMarkets();
        void Update(int id, MarketDto marketDto);

        void Add(MarketDto marketDto);

        void Delete(MarketDto marketDto);
    }
}
