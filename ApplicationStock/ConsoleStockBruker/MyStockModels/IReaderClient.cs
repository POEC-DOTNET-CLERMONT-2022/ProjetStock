using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockModels
{
    public interface IReaderClient
    {
         IWriterClient Writer { get; set; }
         Client create();

         Client update(Client client);
    }
}
