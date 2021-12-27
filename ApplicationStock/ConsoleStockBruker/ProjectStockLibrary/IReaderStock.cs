using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    internal interface IReaderStock
    {
        public IWriterStock Writer { get; set; }
        public Stock create();
        public void read();
    }
}
