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
        IWriterCommande Writer { get; set; }
        Order create(Stock stock);
    }
}
