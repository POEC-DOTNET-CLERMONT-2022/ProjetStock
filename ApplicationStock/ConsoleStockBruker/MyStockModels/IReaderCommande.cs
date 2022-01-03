using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyStockModels
{
    public interface IReaderCommande
    {
        public IWriterCommande Writer { get; set; }
        public Order create(Stock stock);

        public Order update(Order order, Stock stock);

    }
}
