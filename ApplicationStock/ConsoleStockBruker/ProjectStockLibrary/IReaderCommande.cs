using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectStockLibrary
{
    internal interface IReaderCommande
    {
        public IWriterCommande Writer { get; set; }
        public Order create();
        public void read();
    }
}
