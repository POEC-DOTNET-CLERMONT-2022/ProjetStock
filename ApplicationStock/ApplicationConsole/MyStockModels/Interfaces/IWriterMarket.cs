using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace MyStockModels
{
    public interface IWriterMarket
    {
         void Display(string s);

         void DisplayAll(Market item);
    }
}
