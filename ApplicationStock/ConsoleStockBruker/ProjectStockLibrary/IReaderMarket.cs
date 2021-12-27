using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    internal interface IReaderMarket
    {
        public IWriterMarket Writer { get; set; }
        public Market create();
        public void read();
    }
}
