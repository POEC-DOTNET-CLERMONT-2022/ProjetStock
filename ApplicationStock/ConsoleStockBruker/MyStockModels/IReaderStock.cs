using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace MyStockModels
{
    public interface IReaderStock
    {
         IWriterStock Writer { get; set; }
         Stock create();
    }
}
