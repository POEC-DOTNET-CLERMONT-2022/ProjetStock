using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public interface IWriterStock
    {
        public void Display(string s);

        public void DisplayAll(Stock item);
    }
}
