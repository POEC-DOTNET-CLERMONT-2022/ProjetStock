using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectStockPatternsLibrary
{
    public static class StockFactory
    {
        public static IEnumerable<StockDto> ToDto(this IEnumerable<Stock> stocks)
        {
            foreach (var stock in stocks)
            {
                yield return stock.ToDtoStock();
            }
        }


        public static StockDto ToDtoStock(this Stock stock)
        {
            return new StockDto() { _name = stock._name, _entrepriseName = stock._entrepriseName, _value = stock._value };
        }


        public static IEnumerable<Stock> ToModel(this IEnumerable<StockDto> stocks)
        {
            foreach (var stock in stocks)
            {
                yield return stock.ToModelStock();
            }
        }


        public static Stock ToModelStock(this StockDto stock)
        {
            return new Stock() { _name = stock._name, _entrepriseName = stock._entrepriseName, _value = stock._value };
        }
    }
}