using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public interface IReaderStock
    {
        public IWriterStock Writer { get; set; }
        public Stock create();
    }
}
