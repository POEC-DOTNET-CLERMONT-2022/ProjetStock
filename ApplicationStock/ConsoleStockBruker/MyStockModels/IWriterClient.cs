using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockModels
{
    public  interface IWriterClient
    {
        public void Display(string s);

        public void DisplayAll(Client item);

        public void DisplayAllUserStock(List<Stock> _stocks);

        public void DisplayAllUserAddress(List<Address> adresses);
    }
}
