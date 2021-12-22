using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStockModels;

namespace ProjectStockLibrary
{
    public class Reader<TItem> : IReader<TItem>
    {
        public IWriter<TItem> Writer { get; set; }
        public void read()
        {

        }
    }
}
