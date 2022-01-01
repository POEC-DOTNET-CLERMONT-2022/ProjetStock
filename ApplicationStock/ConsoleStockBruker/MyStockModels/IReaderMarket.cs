using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace MyStockModels
{
    public  interface IReaderMarket
    {
        public IWriterMarket Writer { get; set; }
        public Market create();
        public Market update(Market market);

       
    }
}
