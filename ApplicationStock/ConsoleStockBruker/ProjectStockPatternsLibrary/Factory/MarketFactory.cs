using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectStockPatternsLibrary
{
    public  static class MarketFactory
    {
        public static IEnumerable<MarketDto> ToDto(this IEnumerable<Market> markets)
        {
            foreach (var market in markets)
            {
                yield return market.ToDtoStock();
            }
        }

        public static MarketDto ToDtoStock(this Market market)
        {
            return new MarketDto() { _id = market._id,_closingDate= market._closingDate,_openingDate=market._openingDate,_stocks= market._stock,_name=market._name};
        }

        public static IEnumerable<Market> ToDto(this IEnumerable<MarketDto> markets)
        {
            foreach (var market in markets)
            {
                yield return market.ToModelStock();
            }
        }

        public static Market ToModelStock(this MarketDto market)
        {
            return new Market(market._name) { _id = market._id, _closingDate = market._closingDate, _openingDate = market._openingDate, _stock = market._stocks  };
        }
    }
}