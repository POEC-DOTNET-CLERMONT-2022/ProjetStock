using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pro

namespace MyStockModels
{
    public interface IWriter<TItem>
    {
        public void Display(string s);

        public void DisplayAll(TItem item);
    }
}
