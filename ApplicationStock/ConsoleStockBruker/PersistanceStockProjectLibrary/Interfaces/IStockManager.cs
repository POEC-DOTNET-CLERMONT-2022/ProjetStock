using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceStockProjectLibrary
{
    public interface IStockManager
    {
        IEnumerable<StockDto> GetStocks();
       
        StockDto GetById(int id);
        IEnumerable<Stock> GetAllStocks();
        void Update(int id, StockDto stockDto);

        void Add(StockDto stockDto);

        void Delete(StockDto stockDto);
       
    }
}
