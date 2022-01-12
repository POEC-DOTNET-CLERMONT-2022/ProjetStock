using ProjectStockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Interfaces
{
    internal interface IStockRepository
    {
        StockEntity? Add(StockEntity stockDto);

        StockEntity? Update(StockEntity stockDto);


        bool Delete(Guid id);


        StockEntity? GetSingle(Guid id);
    }
}
