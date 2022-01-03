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
        public IWriterClient Writer { get; set; }
        public Client create();

        public Client update(Client client);
    }
}
