using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_application.Dtos;

namespace WCF_application.Manager
{
    public class StockManager
    {
        public IEnumerable<Stock> GetStocks()
        {
            return new List<Stock>() { new Stock() { _id = Guid.NewGuid(), _name = "test", _entrepriseName = "michelin", _value = 1F } };
        }
    }
}